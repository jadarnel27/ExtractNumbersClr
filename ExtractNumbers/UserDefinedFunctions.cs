using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Text;

public static class UserDefinedFunctions
{
    [SqlFunction(
        DataAccess = DataAccessKind.None,
        SystemDataAccess = SystemDataAccessKind.None,
        IsDeterministic = true,
        IsPrecise = true)]
    public static SqlString ExtractNumbersClr(SqlString input)
    {
        var inner = input.Value;
        var builder = new StringBuilder(inner.Length);
        foreach (var character in inner)
        {
            if (char.IsDigit(character))
            {
                builder.Append(character);
            }
        }
        var result = builder.ToString();
        return result.Length == 0 ? null : result;
    }
}