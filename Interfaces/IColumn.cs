using SWH.Models;

namespace SWH.Interfaces;

public interface IColumn
{
    public Task<List<Column>> GetAllColumns();
    public Column GetColumn(string columnID);
    public void AddColumn(Column column);
    public void UpdateColumn(Column column);
    public void DeleteColumn(string columnID);
}