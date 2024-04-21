namespace trilha_net_tdd;

public class FinanceManager
{
    // Variaveis
    public decimal balance {get; private set;}
    private List<decimal> transactions;

    // Construtor da classe, toda vez que instanciar a classe FinanceManager é verificado se o saldo é positivo e a lista já vai ser inicializada
    public FinanceManager(decimal initialBalance) {
        balance = initialBalance < 0 ? 0 : initialBalance; 
        transactions = new List<decimal>();
    }

    // Metodo depositar
    public void Deposit(decimal value) {
        if (value > 0) balance += value;
        transactions.Insert(0, value); // Sempre adiciona o valor no começo da lista
    }

    // Metodo sacar
    public void Withdraw(decimal value) {
        if (value > 0) {
            if (value <= balance) balance -= value;
            else {
                throw new Exception("Saldo insuficiente. Não será possível sacar o saldo.");
            }
        }
        
        transactions.Insert(0, -value); // Sempre adiciona o valor no começo da lista
    }

    // Metodo depositar
    public List<decimal> Transactions() {
        return transactions;
    }
}
