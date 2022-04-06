namespace Application.ViewModels
{
    public class Payment
    {
        public string Number { get; set; }
        public decimal Sum { get; set; }
        //это можно написать при помощи встроенных валидаторов, но так быстрее
    }
}
