using Microsoft.EntityFrameworkCore;
using Sql_Console.Contexts;
using Sql_Console.Models;
using Sql_Console.Models.Entities;

namespace Sql_Console.Services;

internal class IssueService
{
    private static readonly DataContext _context = new DataContext();
    public static async Task SubmitIssueAsync(Issue newIssue)
    {
        var issueEntity = new IssueEntity
        {
            DateOpened = newIssue.DateOpened,
            Title = newIssue.Title,
            Description = newIssue.Description,
            UserId = newIssue.UserId,
            StatusId = newIssue.StatusId
        };
        _context.Add(issueEntity);
        await _context.SaveChangesAsync();
    }

    public static async Task<IEnumerable<Issue>> GetAllIssuesAsync()
    {
        var _issues = new List<Issue>();
        foreach (var _issue in await _context.Issues.Include(x => x.User).Include(x => x.Status).ToListAsync())
        {
            _issues.Add(new Issue
            {
                Id = _issue.Id,
                DateOpened = _issue.DateOpened,
                Title = _issue.Title,
                Description = _issue.Description,
                FirstName = _issue.User.FirstName,
                LastName = _issue.User.LastName,
                Status = _issue.Status.Status
            });
        }
        return _issues;
    }

    public static async Task<Issue> GetIssueByIdAsync(Guid searchedId)
    {
        var _issue = await _context.Issues.Include(x => x.User).Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == searchedId);
        if (_issue != null)
        {
            return new Issue
            {
                Id = _issue.Id,
                DateOpened = _issue.DateOpened,
                Title = _issue.Title,
                Description = _issue.Description,
                FirstName = _issue.User.FirstName,
                LastName = _issue.User.LastName,
                Status = _issue.Status.Status
            };
        }
        else
        {
            return null!;
        }
    }

    public static async Task ChangeIssueStatusAsync(Guid searchedId, int statusCode)
    {
        var _issue = await _context.Issues.FirstOrDefaultAsync(x => x.Id == searchedId);
        if (_issue != null)
        {
            if (_issue.StatusId != statusCode)
            {
                _issue.StatusId = statusCode;
                _context.Update(_issue);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}