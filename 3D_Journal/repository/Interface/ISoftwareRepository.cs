using domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository.Interface
{
    public interface ISoftwareRepository
    {
        List<Software> GetAllWithLogo();
        List<Software> GetAllWithLogoFromIdList(List<Guid> ids);
        Software GetWithLogo(Guid id);
    }
}
