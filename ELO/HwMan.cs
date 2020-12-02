using System;

public class HwMan
{
	public HwMan()
	{
		 public List<huiswerk> huiswerkList;

        public HwMan()
        {
            huiswerkList = new List<huiswerk>();
        }

    public void AddHomeworkToList(string work, string subject, string dueDate, string _class)
    {
        huiswerkList.Add(new Homework(subject, work, dueDate, "Huiswerk", _class));
    }

}
}
