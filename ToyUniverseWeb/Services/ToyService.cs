using System.Collections.Generic;
using ToyUniverseData.Models;
using ToyUniverseData.Repositories;
using ToyUniverseWeb.Models;

namespace ToyUniverseWeb.Services
{
    public interface IToyService
    {
        public PagedResults<Toy> GetToyPage(int currentPage, int pageSize);
        public Toy Find(string id);
    }

    public class ToyService : GenericServices, IToyService
    {
        private IToyRepository _toyRepository;

        public ToyService(IToyRepository operaRepository)
        {
            this._toyRepository = operaRepository;
        }

        public PagedResults<Toy> GetToyPage(int currentPage, int pageSize)
        {
            return GetPaged<Toy>(this._toyRepository.Context.Toys, currentPage, pageSize);
        }

        public Toy Find(string id)
        {
            return this._toyRepository.FindByPrimaryKey(id);
        }


    }
}
