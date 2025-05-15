namespace GymMVC.Exceptions
{
    public class ChooseProgramException:Exception
    {
        public ChooseProgramException():base("Default mesajdir")
        {
            
        }
        public ChooseProgramException(string errormessage):base(errormessage)
        {
            
        }
    }
}

