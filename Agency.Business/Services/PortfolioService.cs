using Agency.Business.Helpers;
using Agency.Business.Services.Interfaces;
using Agency.Core.Models;
using Agency.Core.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Agency.Business.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository portfolioRepository;
        private readonly IPortfolioImageRepository portfolioimg;

        public PortfolioService(IPortfolioRepository portfolioRepository,IPortfolioImageRepository portfolioimg)
        {
            this.portfolioRepository = portfolioRepository;
            this.portfolioimg = portfolioimg;
        }
        public Task CreateAsync(Portfolio portfolio)
        {
            if (portfolio.Image != null)
            {

                if (portfolio.Image.ContentType != "image/png" && portfolio.Image.ContentType != "image/jpeg")
                {
                    throw new Exception();

                }

                if (portfolio.Image.Length > 1048576)
                {
                    throw new Exception();

                }
                string path = "C:\\Users\\ll novbeDesktopNew folder(4)\\WebApplication1\\Agency\\wwwroot\\";
                string newFileName = Helper.GetFileName(path, "upload", portfolio.Image);

                PortfolioImage portfolioImage = new PortfolioImage()
                {
                    PortfolioId=portfolio.Id,
                    ImageUrl=newFileName,
                };
                 portfolioimg.CreateAsync(portfolioImage);

            };

          

           

             portfolioRepository.CreateAsync(portfolio);
            portfolioRepository.CommitAsync();
            return Task.CompletedTask;
        }

     

        public async Task Delete(int id)
        {
            var entity = await portfolioRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);

            if (entity is null) throw new Exception();

            entity.IsDeleted = true;
            portfolioRepository.CommitAsync();
        }

        public Task<List<Portfolio>> GetAllAsync(Expression<Func<Portfolio, bool>>? expression = null)
        {
            return  portfolioRepository.GetAllAsync(expression,"Category");
        }

        

        public Task<Portfolio> GetByIdAsync(int id)
        {
            var entity =  portfolioRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false,"Category");

            if (entity is null) throw new Exception();

            return entity;
        }

        public Task UpdateAsync(Portfolio portfolio)
        {
            throw new Exception();
        }
    }
}
