using MongoDB.Driver;
using SWH.Interfaces;
using SWH.Models;

namespace SWH.Controllers;

public class ProjectController : IProject
{
    DbContext context = new DbContext();

    public async Task<List<Project>> GetAllProjects()
    {
        try
        {
            var projects = context.ProjectRecord.Find(FilterDefinition<Project>.Empty).ToListAsync();
            return await projects;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Project GetProject(string projectID)
    {
        try
        {
            var project = context.ProjectRecord.Find(x => x.id == projectID).FirstOrDefault();
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
            await context.ProjectRecord.InsertOneAsync(project);
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
            await context.ProjectRecord.ReplaceOneAsync(x => x.id == project.id, project);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteProject(string projectID)
    {
        try
        {
            context.ProjectRecord.DeleteOne(x => x.id == projectID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}