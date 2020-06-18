using Application.Common.Mapping;
using AutoMapper;
using Persistences;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Application.UnitTest.Common
{
    public class QueryTestFixture
    {
        public AppDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = AppContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            AppContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
