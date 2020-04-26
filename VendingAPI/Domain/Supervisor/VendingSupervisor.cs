using AutoMapper;
using VendingAPI.Domain.Repositories;

namespace VendingAPI.Domain.Supervisor
{
    public partial class VendingSupervisor : IVendingSupervisor
    {
        private readonly IProductRepository _productRepository;
        private readonly ICoinRepository _coinRepository;
        private readonly IMapper _mapper;

        public VendingSupervisor()
        {
        }

        public VendingSupervisor(IProductRepository productRepository,
                ICoinRepository coinRepository,
                IMapper mapper)
        {
            _productRepository = productRepository;
            _coinRepository = coinRepository;
            _mapper = mapper;
        }
    }
}
