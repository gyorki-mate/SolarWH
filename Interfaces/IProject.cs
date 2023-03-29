using SWH.Models;

namespace SWH.Interfaces;

public interface IProject
{
    public Task<List<Project>> GetAllProjects();
    public Project GetProject(string projectID);
    public void AddProject(Project project);
    public void UpdateProject(Project project);
    public void DeleteProject(string projectID);
}