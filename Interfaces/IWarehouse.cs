using SWH.Models;


namespace SWH.Interfaces;

public interface IWarehouse
{
    public Task<List<Warehouse>> GetAllRows();
    public Warehouse GetRow(string rowID);
    public void AddRow(Warehouse wh);
    public void UpdateRow(Warehouse wh);
    public void DeleteRow(string whID);
}