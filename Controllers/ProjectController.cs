using MongoDB.Driver;
using SWH.Interfaces;
using SWH.Models;

namespace SWH.Controllers;


public class ProjectController : IProject
{
    private readonly DbContext _context = new();

    public async Task<List<Project>> GetAllProjects()
    {
        try
        {
            var projects = _context.ProjectRecord.Find(FilterDefinition<Project>.Empty).ToListAsync();
            return await projects;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Project GetProject(string projectId)
    {
        try
        {
            var project = _context.ProjectRecord.Find(x => x.Id == projectId).FirstOrDefault();
            return project;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void AddProject(Project project)
    {
        try
        {
            project.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
            project.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);

            await _context.ProjectRecord.InsertOneAsync(project);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void UpdateProject(Project project)
    {
        try
        {
            project.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
            await _context.ProjectRecord.ReplaceOneAsync(x => x.Id == project.Id, project);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteProject(string projectId)
    {
        try
        {
            _context.ProjectRecord.DeleteOne(x => x.Id == projectId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}