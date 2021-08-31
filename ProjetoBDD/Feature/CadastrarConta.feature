#language: pt
#encoding: iso-8859-1

Funcionalidade: Cadastrar conta
	como um usuário do sistema
	eu quero cadastrar contas de débito ou crédito
	para que eu possa gerenciar contas

Esquema do Cenário: Cadastro de conta com sucesso.
	Dado Acessar a página de cadastro de conta
	E Informar o nome da conta <nome>
	E Informar o valor da conta <valor>
	E Selecionar o tipo da conta <tipo>
	Quando Solicitar a realização do cadastro da conta
	Então Sistema informa que a conta foi cadastrada com sucesso

Exemplos:
	| nome           | valor  | tipo      |
	| "Salário"      | "1000" | "Crédito" |
	| "Conta de Luz" | "300"  | "Débito"  |