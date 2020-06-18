using Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTest.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly AppDbContext _context;

        public CommandTestBase()
        {
            _context = AppContextFactory.Create();
        }

        public void Dispose()
        {
            AppContextFactory.Destroy(_context);
        }
    }
}
