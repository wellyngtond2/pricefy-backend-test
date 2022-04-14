using Microsoft.EntityFrameworkCore;
using PricefyChallenge.Core.Entities;
using PricefyChallenge.Core.Interfaces.Repository;
using PricefyChallenge.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricefyChallenge.Infra.Repository
{
    public class AttachmentRepository : RepositoryBase<MovieAttachment>, IAttachmentRepository
    {
        public AttachmentRepository(PricefyContext dbContext) : base(dbContext) { }
    }
}
