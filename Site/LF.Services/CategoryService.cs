using LF.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LF.Entities;

namespace LF.Services
{
    public class CategoryService : BaseService
    {
        private readonly BaseRepository<Category> categoryRepository;

        public CategoryService(AllServices parent, BaseRepository<Category> categoryRepository)
            : base(parent)
        {
	        this.categoryRepository = categoryRepository;
        }

        public Category GetById(Int32 CategoryId)
        {
            var Category = categoryRepository.SingleOrDefault(
                c => c.ID == CategoryId
            );

            return Category;
        }

        public IList<Category> GetAll()
        {
            var Categorys = categoryRepository.GetAll();

            return Categorys;
        }
    }
}
