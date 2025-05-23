# DecideAi - Gestão Pública Participativa

Este repositório contém uma aplicação ASP.NET Core desenvolvida em C# com foco em permitir que cidadãos relatem problemas públicos e votem em futuras obras da cidade.

## 🚀 Funcionalidades
- Cadastro e login de usuários
- Relato de problemas com endereço e descrição
- Votação em projetos públicos (educação, saúde, transporte, etc)
- Feedback e avaliação dos serviços
- Ambiente seguro com autenticação JWT e Cookies

## ⚙️ Tecnologias Utilizadas
- ASP.NET Core (.NET 8)
- C# / Razor Views
- Entity Framework Core (Oracle)
- Docker (containerização multi-stage)
- GitHub (versionamento)
- Azure DevOps (CI/CD)
- Azure WebApp (Staging e Produção)

## 📦 Containerização com Docker

Build local da imagem:

```bash
docker build -t decideai-app .
docker run -d -p 8080:80 decideai-app
```

Acesse via navegador: [http://localhost:8080](http://localhost:8080)

## 🔁 CI/CD com Azure DevOps

Pipeline automatizado com:
- Build automático a cada push nas branches `main` e `staging`
- Deploy para Azure WebApp `decideai-staging` (branch staging)
- Deploy para Azure WebApp `decideai-prod` (branch main)

## 🌐 Ambientes

| Ambiente   | WebApp             | Branch Git |
|------------|--------------------|------------|
| Staging    | decideai-staging   | staging    |
| Produção   | decideai-prod      | main       |

## 🧪 Executando localmente

1. Clonar o repositório:
```bash
git clone https://github.com/Piments7/DecideAi
cd DecideAi
```

2. Build com Docker:
```bash
docker build -t decideai-app .
docker run -d -p 8080:80 decideai-app
```

3. Acessar no navegador:
[http://localhost:8080](http://localhost:8080)


