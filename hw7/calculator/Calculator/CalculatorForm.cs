namespace Calculator;

public partial class CalculatorForm : Form
{
    private MyCalculator calculator;
    private string initialData = "";
    private bool shownResult = false;
    private string currentError = "Error";
    private bool equalClicked;
    private bool operationChose;
    private bool operationClicked;
    private bool backClicked;
    private string Data
    {
        get => textNumbers.Text;
        set => textNumbers.Text = value;
    }

    public CalculatorForm()
    {
        InitializeComponent();
        calculator = new MyCalculator();
    }

    private void buttonDigital_Click(object sender, EventArgs e)
    {
        Data = string.Compare(Data, initialData) == 0 || shownResult ? (sender as Button).Text : Data + (sender as Button).Text;
        shownResult = false;
        operationClicked = false;
        backClicked = false;
    }

    private void buttonDecimalDot_Click(object sender, EventArgs e)
    {
        if (shownResult)
        {
            shownResult = false;
            Data = initialData;
        }
        if (Data.Contains(','))
        {
            return;
        }
        Data = string.Compare(Data, initialData) == 0 ? "0," : Data.Insert(Data.Length, ",");
        backClicked = false;
        equalClicked = false;
        operationClicked = false;
    }

    private void buttonBackspace_Click(object sender, EventArgs e)
    {
        if (string.Compare(Data, currentError) == 0 || shownResult)
        {
            return;
        }
        Data = Data.Length <= 1 || (Data.Length == 2 && Data[0] == '-') ? initialData : Data.Remove(Data.Length - 1);
        shownResult = false;
        backClicked = true;
    }

    private void buttonClearAll_Click(object sender, EventArgs e)
    {
        calculator.Clear();
        Data = initialData;
        //shownResult = false;
        operationChose = false;
        equalClicked = false;
        operationClicked = false;
    }

    private void TryCalculate()
    {
        try
        {
            Data = calculator.Calculate().ToString();
        }
        catch (ArgumentNullException ex)
        {
            Data = currentError;
            calculator.Clear();
            operationChose = false;
            operationClicked = false;
            backClicked = false;
        }
        catch (DivideByZeroException ex)
        {
            Data = currentError;
            calculator.Clear();
            operationChose = false;
            operationClicked = false;
            backClicked = false;
        }
    }

    private void buttonOperation_Click(object sender, EventArgs e)
    {
        if (string.Compare(Data, currentError) == 0)
        {
            return;
        }
        if (string.Compare(Data, initialData) == 0 && !backClicked)
        {
            return;
        }    
        if (!shownResult)
        {
            if (equalClicked)
            {
                calculator.Clear();
                operationChose = false;
            }
            if (string.Compare(Data, initialData) != 0)
            {
                calculator.AssignNumber(Convert.ToDouble(Data));
                if (operationChose)
                {
                    TryCalculate();
                }
            }
        }
        calculator.AssignOperation(Convert.ToChar((sender as Button).Text));
        shownResult = true;
        operationChose = true;
        equalClicked = false;
        operationClicked = true;
        backClicked = false;
    }

    private void buttonEqual_Click(object sender, EventArgs e)
    {
        if (string.Compare(Data, initialData) == 0)
        {
            return;
        }
        if (!shownResult || !equalClicked)
        {
            calculator.AssignNumber(Convert.ToDouble(Data));
        }
        if (operationChose && !operationClicked)
        {
            TryCalculate();
        }
        shownResult = true;
        equalClicked = true;
        backClicked = false;
    }
}