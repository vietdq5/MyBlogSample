using System;

namespace SieuNhanGao.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}