using Microsoft.EntityFrameworkCore;
using Sql_Console.Contexts;
using Sql_Console.Models;
using Sql_Console.Models.Entities;

namespace Sql_Console.Services;

internal class CommentService
{
    private static readonly DataContext _context = new DataContext();
    public static async Task SubmitCommentAsync(Comment newComment)
    {
        var commentEntity = new CommentEntity
        {
            Comment = newComment.CommentString,
            CommentDate = newComment.CommentDate,
            IssueId = newComment.IssueId
        };
        _context.Add(commentEntity);
        await _context.SaveChangesAsync();
    }
    public static async Task<IEnumerable<Comment>> GetAllCommentsForIssueAsync(Guid issueId)
    {
        var _comments = new List<Comment>();
        foreach (var _comment in await _context.Comments.Where(x => x.IssueId == issueId).ToListAsync())
        {
            _comments.Add(new Comment
            {
                Id = _comment.Id,
                CommentDate = _comment.CommentDate,
                CommentString = _comment.Comment,
                IssueId = _comment.IssueId
            });
        }
        return _comments;
    }
}
