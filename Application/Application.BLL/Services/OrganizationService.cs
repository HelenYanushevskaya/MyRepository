using Application.BLL.DTO;
using Application.BLL.Interfaces;
using Application.DAL.Entities;
using Application.DAL.Interfaces;

namespace Application.BLL.Services
{
    class OrganizationService : IOrganizationService
    {
        IUnitOfWork Database { get; set; }

        public OrganizationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void MakeOrganisation(OrganizationDTO organisationDto)
        {
            OrganizationEntity organization = new OrganizationEntity
            {
                Address = organisationDto.Address,
                Email = organisationDto.Email,
                Phone = organisationDto.Phone,
                Name = organisationDto.Name
                           
            };
            Database.Organizations.Create(organization);
            Database.Save();
        }
    }
}
