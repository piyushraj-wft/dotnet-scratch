public interface IOrganizationRepository
{
    Task<bool> CreateOrganization(Organization organization);


}