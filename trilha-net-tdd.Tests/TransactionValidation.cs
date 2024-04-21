namespace trilha_net_tdd.Tests;

public class FinanceManagerTests
{

    [Theory]
    [InlineData(0)]
    [InlineData(700)]
    [InlineData(007)]
    [InlineData(123.4)]
    public void InitialBalance_GetCurrentBalance(decimal initialBalance) // verifica se o saldo está configurado corretamente, garante que ao criar uma conta bancaria com um saldo inicial especifico, o saldo dessa conta seja igual ao valor inicial esperado 
    {
        var account = new FinanceManager(initialBalance);
        Assert.Equal(initialBalance, account.balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(100)]
    [InlineData(32.9)]
    public void Deposit_AddIncome_UpdateBalance(decimal deposit) // verifica se o deposito é feito com sucesso
    {
        //Arrange
        var account = new FinanceManager(700);
        decimal initialBalance = account.balance;

        //Act
        account.Deposit(deposit);

        //Assert
        Assert.Equal(initialBalance + deposit, account.balance);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-63.7)]
    public void Deposit_AddNegativeIncome_NotChangeBalance(decimal deposit) // deposito não é feito quando escreve valores negativos
    {
        var account = new FinanceManager(700);
        decimal initialBalance = account.balance;
        decimal depositAmount = deposit;

        account.Deposit(depositAmount);

        Assert.Equal(initialBalance, account.balance);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(200)]
    [InlineData(612.3)]
    public void Withdraw_AddExpense_UpdateBalance(decimal withdraw) // verifica se o saque é feito com sucesso
    {
        //Arrange
        var account = new FinanceManager(700);
        decimal initialBalance = account.balance;

        //Act
        account.Withdraw(withdraw);

        //Assert
        Assert.Equal(initialBalance - withdraw, account.balance);
    }

    [Fact]
    public void Withdraw_AddNegativeExpense_BalanceDoesntChangeIfWithdrawGreaterBalance() // saldo não altera se o saque for maior que o saldo
    {
        var account = new FinanceManager(1);
         //1, account.balance
        Assert.Throws<Exception>(() => account.Withdraw(2));
    }

    [Fact]
    public void ViewTransactions_ListAllTransactions() // verifica se as transações estão sendo implementadas na lista de transações
    {
        //Arrange
        var account = new FinanceManager(700);
        account.Withdraw(50);
        account.Deposit(100);

        //Act
        var listTransactions = account.Transactions();

        //Assert
        Assert.Collection(
            listTransactions, 
            item => Assert.Equal(-50, item),
            item => Assert.Equal(100, item)
        );
    }
}