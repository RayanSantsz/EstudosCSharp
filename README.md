# MeuPrimeiroProjeto — Trilha de Estudos ASP.NET Core (v2)

Reinício completo da trilha, do zero, em **.NET 10 (LTS)** + **Visual Studio 2026**. Este README documenta o progresso atualizado: o que já foi estudado, com que profundidade, e o que ainda falta.

**Analogia guia usada durante todo o estudo:** a API é um restaurante. O Controller é o gerente de setor, o endpoint é uma porta numerada, o verbo HTTP é a intenção do pedido, o Model é a ficha de um prato, o middleware é a esteira por onde cada pedido passa, e o Repositório é o almoxarifado que guarda os dados de verdade.

**Método de estudo:** sem código pronto entregue — cada exercício é tentado primeiro pelo aluno, corrigido com pistas (nunca a resposta direta), e só avança quando o conceito está consolidado.

---

## ✅ Fundamentos de C# — Concluído até aqui

### Ambiente e estrutura
- Visual Studio 2026, .NET 10 SDK
- Top-level statements (o compilador monta o `Main` escondido a partir das instruções soltas)
- Implicit usings (bibliotecas comuns já "importadas" automaticamente)
- **Regra de ordem no arquivo:** instruções soltas (executáveis) sempre vêm primeiro no arquivo; declarações de `class` sempre vêm depois, no final — misturar a ordem gera erro de compilação. Já debugado na prática mais de uma vez.

### Console básico
- `Console.WriteLine` (escreve e quebra linha) vs `Console.Write` (escreve e mantém na mesma linha)

### Variáveis e tipos
- `string`, `decimal` (com sufixo `m` obrigatório em literais, para não confundir com `double`), `bool`, `int`, `double`, `char`
- Interpolação de string (`$"texto {variavel}"`) como forma preferida de montar mensagens com dados

### Métodos
- Parâmetros, `void` (efeito colateral, sem retorno) vs `return` (devolve um valor)
- Diferença entre **declarar** um método (`nomeDoMetodo`, sem parênteses) e **chamar** ele (`nomeDoMetodo(argumentos)`)
- Cuidado com tipos incompatíveis em operações (ex: `decimal` não pode ser atribuído direto a uma variável `int` sem perda de precisão)

### Operadores e condicionais
- `==`, `!=`, `>`, `<`, `>=`, `<=`, `&&`, `||`
- `if` / `else if` / `else`
- Boas práticas: evitar `== true` / `== false` redundante em condições booleanas (usar a variável direto, ou `!variavel` para negar)

### Arrays e `List<T>`
- Array: tamanho fixo, precisa de `new` + chaves `{ }` para os valores iniciais
- `List<T>`: tamanho dinâmico, precisa de `new List<T>()` antes de usar `.Add()`
- `.Add()`, `.Remove()`, `.Count` (propriedade, sem parênteses)
- `foreach` para percorrer coleções

### Orientação a Objetos I — Classes, objetos, construtores, encapsulamento
- Classe = ficha técnica (molde) / Objeto = instância real criada com `new`
- Construtor: mesmo nome da classe, roda automaticamente na criação do objeto
- Encapsulamento com `private set`: só a própria classe altera a propriedade; quem usa de fora só lê
- Validação dentro do construtor (com `throw new Exception(...)`), feita **antes** de atribuir os valores às propriedades — boa prática identificada durante a correção

### Orientação a Objetos II — Herança e Polimorfismo (parcial)
- Herança com `:` — classe filha herda propriedades e métodos da classe mãe
- `base(...)` no construtor da filha, repassando valores para o construtor da mãe
- Polimorfismo com `virtual` (na mãe, "pode ser reescrito") / `override` (na filha, "estou reescrevendo")
- Regra de assinatura: método `override` precisa ter exatamente os mesmos parâmetros do `virtual` da mãe
- Boa prática: `base.Metodo()` reaproveita o comportamento comum da mãe, e a filha complementa só com o que é exclusivo dela — evita duplicar lógica e saída repetida

---

## ⏳ Em andamento — Orientação a Objetos II (continuação)

Exercício em andamento no momento da pausa: criar a interface `IDescontavel` (com `void AplicarDesconto(decimal percentual)`), implementá-la na classe `Pedido`, e aplicar desconto sobre `Preco` respeitando o encapsulamento (`private set`).

**Próximos passos (retomar daqui):**
- Finalizar a implementação de `IDescontavel` em `Pedido`
- Testar `AplicarDesconto` e comparar `Preco` antes/depois via `Apresentar()`
- Classes abstratas (`abstract class`, métodos `abstract` sem corpo, impedindo `new` direto na classe)
- Interfaces — aprofundar (diferença de "herda de uma classe" vs "implementa várias interfaces")
- Pattern matching (`is Tipo variavel`)

---

## 🔜 Próximos tópicos — Fundamentos de C# (ainda não iniciados nesta rodada)

- Tratamento de exceções: `try` / `catch` / `finally`, exceções customizadas
- Generics (`Par<T1, T2>`)
- Delegates, Eventos (`event`, `?.Invoke`)
- Lambdas (`(a, b) => ...`)
- LINQ (`Where`, `Select`, `OrderByDescending`, `FirstOrDefault`)

---

## 🔜 ASP.NET Core — A retomar após fechar os fundamentos de C#

*(Nesta rodada de estudo, ainda não foi reiniciado — o conteúdo abaixo é o roteiro planejado, na versão atualizada para .NET 10.)*

### Módulo 1 — Ambiente, primeiro projeto e estrutura
- O que é o ASP.NET Core e como se encaixa no .NET
- Criação do projeto (Web API, .NET 10, com Swagger)
- `Program.cs`: fase de configuração (`builder.Services.Add...`) vs fase de pipeline (`app.Use...`)
- Middleware como esteira: cada requisição passa pelas estações, na ordem escrita

### Módulo 2 — Fundamentos de C# aplicados à web
- Classe vs Objeto aplicado a um contexto real (`Pedido` como "ficha em branco")
- Propriedades como os "espaços em branco" da ficha

### Módulo 3 — Minimal APIs
- Endpoint como "porta numerada": endereço + verbo HTTP
- `app.MapGet`, `app.MapPost` com lambdas
- `Results.Ok()`, `Results.NotFound()`, `Results.Created()`
- Parâmetro de rota (`{mesa}`) e busca com `FirstOrDefault`

### Módulo 4 — Controllers e organização MVC
- Controller como "gerente de setor", herdando de `ControllerBase`
- Atributos `[ApiController]`, `[Route("[controller]")]`, `[HttpGet]`, `[HttpPost]`, `[FromBody]`
- `builder.Services.AddControllers()` + `app.MapControllers()`
- Migração de rotas do `Program.cs` para um Controller dedicado

### Módulo 5 — Injeção de Dependência e Padrão Repositório
- Problema: lista `static` dentro do Controller mistura responsabilidades
- Padrão Repositório: interface (contrato) + implementação real
- Registro no container (`AddSingleton<IInterface, Implementacao>`)
- Injeção via construtor, Inversão de Controle (IoC)

### Módulo 6 — Entity Framework Core
- ORM: trabalhar com banco de dados usando objetos C#, sem SQL manual
- SQLite como banco local
- `AppDbContext`, `DbSet<T>`
- Connection string, `AddDbContext`, migrations (`dotnet ef migrations add`, `dotnet ef database update`)
- Nova implementação de repositório usando EF Core, trocando só o registro no `Program.cs` (graças à interface)

### Módulos seguintes (planejados)
- Relacionamentos entre entidades — 1:N, N:N, chaves estrangeiras, propriedades de navegação
- DTOs, validação e mapeamento — DataAnnotations/FluentValidation, AutoMapper
- Autenticação e Autorização — ASP.NET Core Identity, JWT, `[Authorize]`
- Middlewares personalizados e tratamento global de erros — logging estruturado, exceções centralizadas
- Testes automatizados — xUnit (unidade e integração)
- Deploy — Docker, IIS ou Azure/Linux
