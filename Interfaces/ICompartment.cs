using SWH.Models;

namespace SWH.Interfaces;

public interface ICompartment
{
    public Task<List<Compartment>> GetAllCompartments();
    public Compartment GetCompartment(string compartmentId);
    public void AddCompartment(Compartment compartment);
    public Task<string>? UpdateCompartment(Compartment compartment);
    public void DeleteCompartment(string compartmentId);
}