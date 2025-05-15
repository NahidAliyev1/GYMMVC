using GymMVC.Contexts;
using GymMVC.Exceptions;
using GymMVC.Models;
using GymMVC.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace GymMVC.Services;

public class ChooseProgramService
{
    private readonly AppDbContext _context;
    public ChooseProgramService()
    {
        _context = new AppDbContext();
    }
    #region Read
    public List<ChooseProgram> GetAllChooseProgram()
    {
        List<ChooseProgram> choosePrograms = _context.ChoosePrograms.ToList();
        return choosePrograms;
    }
    public ChooseProgram GetChooseProgramById(int id)
    {
        ChooseProgram? chooseProgram = _context.ChoosePrograms.Find(id);
        if (chooseProgram is null)
        {
            throw new ChooseProgramException($"Databasada  {id} idsi tapilmadi");

        }
        return chooseProgram;
    }
    #endregion

    #region Create
    public void CreateChooseProgram(ChooseProgramVM chooseProgramVM) 
    {
        ChooseProgram newchooseProgram = new ChooseProgram();
        newchooseProgram.Name = chooseProgramVM.Name;
        newchooseProgram.Description = chooseProgramVM.Description;

        string fileName = Path.GetFileNameWithoutExtension(chooseProgramVM.ImgFile.FileName);
        string extension = Path.GetExtension(chooseProgramVM.ImgFile.FileName);
        string resultName = fileName + Guid.NewGuid().ToString() + extension;
        string uploadedPath = $"C:\\Users\\II Novbe\\source\\repos\\GymMVC\\GymMVC\\wwwroot\\assets\\uploadedImages\\";

        if (!Directory.Exists(uploadedPath))
        {
            Directory.CreateDirectory(uploadedPath);
        }
        uploadedPath = Path.Combine(uploadedPath, resultName);

        using FileStream fileStream = new FileStream(uploadedPath, FileMode.Create);


        chooseProgramVM.ImgFile.CopyTo(fileStream);





        newchooseProgram.ImgPath = resultName;

        _context.ChoosePrograms.Add(newchooseProgram);
        _context.SaveChanges();
    }
    #endregion
    #region Update
    public void UpdateChooseProgram(int id, ChooseProgram chooseProgram) 
    {
        if (chooseProgram.Id!=id)
        {
            throw new ChooseProgramException($"Id ler ust uste dusmur");
        }
        ChooseProgram? chooseProgram1 = _context.ChoosePrograms.AsNoTracking().SingleOrDefault(ch =>ch.Id==id);
        if (chooseProgram1 is not null)
        {
            _context.Update(chooseProgram1);
            _context.SaveChanges();
        }
        else
        {
            throw new ChooseProgramException($"databasada {id} idisi tapilamdi");
        }
    }
    #endregion
    #region Delete
    public void DeleteChooseProgram(int id) 
    {
        ChooseProgram? chooseProgram = _context.ChoosePrograms.Find(id);
        if (chooseProgram is null)
        {
            throw new ChooseProgramException($"Databasada bu {id} id tapilmadi");
        }
        _context.Remove(chooseProgram);
        _context.SaveChanges();
    }
    #endregion

  
}
