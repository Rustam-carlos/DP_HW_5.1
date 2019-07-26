using System;
using System.Collections.Generic;

namespace DP_HW_5._1
{
    class Patient
    {
        private int medicament = 10;         
        public void Reception()
        {
            if (medicament > 0)
            {
                medicament--;
                Console.WriteLine("Принемаем лекарство. Осталось {0} таблеток/уколов", medicament);
            }
            else
                Console.WriteLine("Курс медикаментов окончен");
        }        
        public PatientMemento SaveState()
        {
            Console.WriteLine("Запись приема лекарств. Курс - {0} таблеток/уколов", medicament);
            return new PatientMemento(medicament);
        }
        public void RestoreState(PatientMemento memento)
        {
            this.medicament = memento.Medicament;            
            Console.WriteLine("Назначение курса. Курс - {0} таблеток/уколов", medicament);
        }
    }
    // Memento
    class PatientMemento
    {
        public int Medicament { get; private set; }        

        public PatientMemento(int patrons)
        {
            this.Medicament = patrons;            
        }
    }

    // Caretaker
    class PatientHistory
    {
        public Stack<PatientMemento> History { get; private set; }
        public PatientHistory()
        {
            History = new Stack<PatientMemento>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Patient patient = new Patient();
            patient.Reception(); 
            PatientHistory history = new PatientHistory();

            history.History.Push(patient.SaveState());

            patient.Reception();

            patient.RestoreState(history.History.Pop());

            patient.Reception();

            Console.Read();
        }
    }
}
