
using System.Data;
using Dapper;

public class OrganizationRepository(IDbConnection _dbConnection) : IOrganizationRepository
{
    public async Task<bool> CreateOrganization(Organization organization)
    {

        //databse 
        //sql 
        try
        {
            var sql = "INSERT INTO organization (id,name,image) VALUES (@Id, @Name, @Image)";
            var result = await _dbConnection.ExecuteAsync(sql, organization);
            return true;
        }
        catch (Exception)
        {
            throw;
        }

    }
}