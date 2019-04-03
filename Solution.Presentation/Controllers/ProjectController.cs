using iTextSharp.text;
using iTextSharp.text.pdf;
using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class ProjectController : Controller
    {
        User u = new User();

        IProjectService MyProjectService;
        IUserService MyUserService;

        public ProjectController()
        {
            MyProjectService = new ProjectService();
            MyUserService = new UserService();
        }
        // GET: Project
        //affichage
        public ActionResult Index(string searchString)
        {
            var Projects = new List<ProjectVM>();

            foreach (Project f in MyProjectService.SearchProjectsByName(searchString))
            {
                Projects.Add(new ProjectVM()
                {
                    Id = f.Id,
                    Titre = f.Titre,
                    Description = f.Description,
                    Branche = (BrancheVM)f.Branche,
                    ImageUrl = f.ImageUrl,
                    OutDate = f.OutDate,
                    UserId = f.UserId
                });
            }
            return View(Projects);
        }

        [HttpGet]
        // GET: Project/Details/5
      
        public ActionResult Details(int id)
        {
            Project p = MyProjectService.GetProjectById(id);
            //}
            ProjectVM VM = new ProjectVM();
            VM.Titre = p.Titre;
            VM.Description = p.Description;
            VM.Branche = (BrancheVM)p.Branche;
            VM.ImageUrl = p.ImageUrl;
            VM.OutDate = p.OutDate;
            VM.UserId = p.UserId;

            return View(VM);

        }


        // GET: Project/Create
        [HttpGet]
        public ActionResult Create()
        {
            var MyUsers = MyUserService.GetMany();
            ViewBag.ListUsers = new SelectList(MyUsers, "UserId", "FirstName");
            //viewbag :variable pour tronsporter les données du controller lil vue 
            return View();
        }

        // POST: Project/Create
        //ajout base
        [HttpPost]
        public ActionResult Create(ProjectVM ProjectVM, HttpPostedFileBase Image)
        {
            Project ProjectsDomain = new Project()
            {

                Description = ProjectVM.Description,
                Branche = (Branche)ProjectVM.Branche,
                ImageUrl = Image.FileName,
                OutDate = ProjectVM.OutDate,
                Titre = ProjectVM.Titre,
                UserId = ProjectVM.UserId
            };
            MyProjectService.Add(ProjectsDomain);
            MyProjectService.Commit();
            //ajout de l'image dans un dossier Upload
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);

            return RedirectToAction("Index");
        }
        [HttpGet]
        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            Project p = MyProjectService.GetProjectById(id);
            ProjectVM VM = new ProjectVM();

            //if (p == null)
            // {
            //return HttpNotFound();
            //   return View();
            //  }


            VM.Titre = p.Titre;
            VM.Description = p.Description;
            VM.Branche = (BrancheVM)p.Branche;
            VM.ImageUrl = p.ImageUrl;
            VM.OutDate = p.OutDate;
            VM.UserId = p.UserId;

            return View(VM);
        }



        // POST: Project/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectVM VM)
        {


            try
            {
                // TODO: Add update logic here
                Project p1 = MyProjectService.GetProjectById(id);

                p1.Titre = VM.Titre;
                p1.Description = VM.Description;
                //(BrancheVM)p1.Branche = VM.Branche;
                p1.ImageUrl = VM.ImageUrl;
                p1.OutDate = VM.OutDate;
                p1.UserId = VM.UserId;
                MyProjectService.Update(p1);
                MyProjectService.Commit();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(VM);
            }
        }

        [HttpGet]
        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            Project p = MyProjectService.GetProjectById(id);
            //}
            ProjectVM VM = new ProjectVM();
            VM.Titre = p.Titre;
            VM.Description = p.Description;
            VM.Branche = (BrancheVM)p.Branche;
            VM.ImageUrl = p.ImageUrl;
            VM.OutDate = p.OutDate;
            VM.UserId = p.UserId;

            return View(VM);
        }



        [HttpPost]
        // POST: Project/Delete/5
        public ActionResult Delete(int id, ProjectVM VM)
        {
            try
            {
                // TODO: Add delete logic here
                Project p = MyProjectService.GetProjectById(id);
                MyProjectService.Delete(p);
                MyProjectService.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





        /* public ActionResult pdf()
         {
             FileStream fs = new FileStream("c://pdf/report.pdf", FileMode.Create);
             Document document = new Document(iTextSharp.text.PageSize.LETTER, 0, 0, 0, 0);
             PdfWriter pw = PdfWriter.GetInstance(document, fs);
             document.Open();
             document.Add(new Paragraph("hallo"));
             document.Close();

             return null;

         }
         */




        public void pdf()
        {
            foreach (Project p in MyProjectService.GetProjectById1())
            {
                Document pdfDoc = new Document(PageSize.A4, 0, 0, 0, 0);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                using (MemoryStream stream = new MemoryStream())
                {
                    pdfDoc.NewPage();

                    Paragraph para = new Paragraph("Le titre de ce projet est\n " + p.Titre);
                    Paragraph para1 = new Paragraph("La Description est:  \n" + p.Description);
                    Paragraph para2 = new Paragraph("La branche du projet est \n" + (BrancheVM)p.Branche);
                    Paragraph para3 = new Paragraph("Project \n" + p.ImageUrl);
                    Paragraph para4 = new Paragraph("ce projet est mis à notre disposition a la date \n" + p.OutDate);


                    pdfDoc.Add(para);
                    pdfDoc.Add(para1);
                    pdfDoc.Add(para2);
                    pdfDoc.Add(para3);
                    pdfDoc.Add(para4);


                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    string nom = ("/") + ("Project.pdf");
                    // Response.AddHeader("content-disposition", "attachment;filename=" + nom);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }










    }
}