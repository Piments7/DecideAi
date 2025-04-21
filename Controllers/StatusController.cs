using DecideAi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Decide.Ai.Web.Controllers
{
	public class StatusController : Controller
	{
		private List<StatusModel> _status;
		public IList<MotivoModel> Motivos { get; private set; }

		public StatusController()
		{
			_status = GerarStatusMocados();
			Motivos = new List<MotivoModel>();
		}

		public IActionResult Index()
		{
			return View(_status);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var motivos = new List<string> { "Buracos", "Iluminação pública", "Lixo não coletado", "Outros" };

			ViewBag.MotivosList = new SelectList(motivos);

			return View();
		}

		[HttpPost]
		public IActionResult Create(StatusModel statusModel, string SelectedMotivo)
		{
			Console.WriteLine("Solicitação enviada com sucesso.");

			ViewBag.Message = $"Você selecionou: {SelectedMotivo}";

			var motivos = new List<string> { "Buracos", "Iluminação pública", "Lixo não coletado", "Outros" };
			ViewBag.MotivosList = new SelectList(motivos);

			TempData["mensagemSucesso"] = "Solicitação feita com sucesso.";

			return RedirectToAction(nameof(Index));

		}



		[HttpGet]
		public IActionResult Edit(int id)
		{
			if (!Motivos.Any())
			{
				Motivos = GerarMotivosMocados();
			}

			var selectListMotivos = new SelectList(Motivos, nameof(StatusModel.StatusId), nameof(StatusModel.Motivo));
			ViewBag.Motivos = selectListMotivos;

			var statuSolicitado = _status.FirstOrDefault(c => c.StatusId == id);
			if (statuSolicitado == null)
			{
				return NotFound("Status não encontrado.");
			}

			return View(statuSolicitado);
		}

		[HttpPost]
		public IActionResult Edit(StatusModel statusModel)
		{
			if (!ModelState.IsValid)
			{
				TempData["mensagemErro"] = "Erro ao editar a solicitação.";
				return View(statusModel);
			}

			TempData["mensagemSucesso"] = $"Dados da Solicitação {statusModel.StatusId} foram alterados com sucesso.";
			return RedirectToAction(nameof(Index));
		}


		[HttpGet]
		public IActionResult Delete(int id)
		{
			var statusSolicitado =
				_status.Where(c => c.StatusId == id).FirstOrDefault();
			if (statusSolicitado != null)
			{
				TempData["mensagemSucesso"] = $"Os dados da solicitação {statusSolicitado.StatusId} foram apagados com sucesso";
			}
			else
			{
				TempData["mensagemSucesso"] = $"OPS !!! Solicitação Apagada.";
			}
			return RedirectToAction(nameof(Index));
		}

		public static List<StatusModel> GerarStatusMocados()
		{
			var status = new List<StatusModel>();

			for (int i = 1; i <= 5; i++)
			{
				var statu = new StatusModel
				{
					StatusId = i,
					EnderecoLocal = "EnderecoLocal" + i,
					Numero = i,
					Cep = i,
					Bairro = "Bairro" + i,
					Descricao = "Descrição" + i,

					Usuario = new UsuarioModel()
					{
						Nome = "Nome" + i,
						
						CPF = "Cpf" + i,
						Telefone = "Telefone" + i

					}
				};

				status.Add(statu);
			}

			return status;

		}

		private static List<MotivoModel> GerarMotivosMocados()
		{
			return new List<MotivoModel>
		{
			new MotivoModel { MotivoId = 2, Motivo = "Iluminação pública" },
			new MotivoModel { MotivoId = 3, Motivo = "Lixo não coletado" },
			new MotivoModel { MotivoId = 4, Motivo = "Outros" },
			new MotivoModel { MotivoId = 1, Motivo = "Buracos" },
		};
		}
	}

}