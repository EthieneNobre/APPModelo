using DevIO.UI.Site.Data;
using DevIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;
        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Ethiene",
                DataNascimento = DateTime.Now,
                Email = "ethienenobre@gmail.com"

            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var _aluno = _contexto.Alunos.Find(aluno.Id);
            var _alu = _contexto.Alunos.Find(aluno.Id);

            aluno.Nome = "Carlos";
            _contexto.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Remove(aluno);
            _contexto.SaveChanges();


  

            return View();
        }
    }
}
