using System.Diagnostics;
using heikedin.Models;
using heikedin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace heikedin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new FormViewModel());
        }

        [HttpPost]
        public IActionResult Index(FormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Por favor, preencha todos os campos obrigatórios.";
                return View(viewModel);
            }

            string cpfLimpo = viewModel.CPF.Replace(".", "").Replace("-", "");
            if (cpfLimpo.Length != 11)
            {
                TempData["Error"] = "CPF inválido";
                return View(viewModel);
            }

            try
            {
                var model = new FormModel
                {
                    Nome = viewModel.Nome,
                    CPF = cpfLimpo,
                    DataNascimento = viewModel.DataNascimento,
                    Curso = viewModel.Curso,
                    Descricao = viewModel.Descricao
                };

                _context.Forms.Add(model);
                _context.SaveChanges();
                TempData["Success"] = "Nossa equipe entrará em contato em breve. Agradecemos a participação";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar o formulário");
                TempData["Error"] = "Ocorreu um erro ao processar sua solicitação.";
                return View(viewModel);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
