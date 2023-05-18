using ApiEntidades.Models;

namespace ApiEntidades.Repositories
{
    public class CampoRepository : ICampoRepository
    {
        //implement interface
        private readonly AppDbContext _context;

        public CampoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Campo campo)
        {

            if (campo != null)

            {
                _context.Campos.Add(campo);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(campo));
            }
        }

        public void Delete(int id)
        {

        }

        public IEnumerable<Campo> GetAll()
        {
            return _context.Campos.ToList();
        }

        public Campo GetById(int id)
        {
            return _context.Campos.FirstOrDefault(p => p.Id == id);

        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void Update(Campo campo)
        {
            throw new NotImplementedException();
        }
    }
}
