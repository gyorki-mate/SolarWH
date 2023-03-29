using SWH.Models;


namespace SWH.Interfaces;

public interface IRow
{
    public Task<List<Row>> GetAllRows();
    public Row GetRow(string rowID);
    public void AddRow(Row row);
    public void UpdateRow(Row row);
    public void DeleteRow(string rowID);
}