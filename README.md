<div align="center">

# CRUD de um aplicativo de series
> Projeto prático do bootcamp Decola Tech 2, cujo objetivo era desenvolver um CRUD de um app de series, + implementação com WebAPI

</div>

<br><br>

- Nesse projeto tinha como base criar um algoritmo simples de cadastro de séries para praticar conhecimentos de orientação a objetos, o principal paradigma de programação utilizada no mercado. Nesse projeto foi aprendido: Como pensar orientado a objetos e como utilizar recursos de coleção para salvar dados em memória (`Instrutor: Eliézer Zarpelão`). <br>

- Nesse projeto também foi implementado utilizando WebAPI (`Instrutor: Victor Fructuoso`).

### - Opções do app (Versão Console):
> ![p1](https://user-images.githubusercontent.com/60985347/145585518-81dff3a5-d616-477c-841e-30206ea1597b.png)
>
> Obs: Caso você for testar, você pode descomentar a linha 13 de `DioSeries.Console/Program.cs`, essa linha chama um método para deixar algumas series já criadas para agilizar os testes (Testes pelo Console)

<br>
<br>
<br>

### - Versão WebApi
Para realizar os teste nessa versão do projeto foi utilizado o aplicativo **[Postman](https://www.postman.com/downloads/)** para agilizar as consultas do repositório.

<!--------------------------------------- Tabela -->
> Obs: {id} corresponde a um tipo numérico
>
> <table>
  <!----------- Linha 1-->
  <tr>
    <th>Função</th>
    <th>Método HTTP</th>
    <th>Rota</th>
  </tr>
  <!----------- Linha 2-->
  <tr>
    <td/>
    <td/>
    <td/>
  </tr>
  <!----------- Linha 3-->
  <tr>
    <th>Listar Séries</th>
    <th>[GET]</th>
    <th>https://localhost:44318/serie</th>
  </tr>
  <!----------- Linha 4-->
  <tr>
    <th>Consultar Série</th>
    <th>[GET]</th>
    <th>https://localhost:44318/serie/{id}</th>
  </tr>
  <!----------- Linha 5-->
  <tr>
    <th>Atualizar Série</th>
    <th>[PUT]</th>
    <th>https://localhost:44318/serie/{id}</th>
  </tr>
  <!----------- Linha 6-->
  <tr>
    <th>Inserir Série</th>
    <th>[POST]</th>
    <th>https://localhost:44318/serie/{id}</th>
  </tr>
  <!----------- Linha 7-->
  <tr>
    <th>Deletar Série</th>
    <th>[DELETE]</th>
    <th>https://localhost:44318/serie/{id}</th>
  </tr>
</table>
