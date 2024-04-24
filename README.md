# Integração com Impressora Bematech MP-4200

Este projeto consiste em um programa desenvolvido em C# para realizar comunicação direta com a DLL da impressora Bematech MP-4200. O objetivo principal é permitir a impressão de documentos em bobina térmica, bem como realizar a abertura da gaveta e utilizar outras funcionalidades disponíveis na DLL.

## Pré-requisitos

- Sistema operacional Windows
- Impressora Bematech MP-4200 instalada e configurada
- SDK (Software Development Kit) da Bematech para a MP-4200, contendo a DLL necessária para comunicação com a impressora.

## Funcionalidades

- Impressão de documentos em bobina térmica.
- Abertura da gaveta.
- Outras funcionalidades disponíveis na DLL da impressora Bematech MP-4200.

## Instalação

1. Clone este repositório para o seu ambiente local.
2. Certifique-se de ter o SDK da Bematech instalado e configurado corretamente em seu ambiente de desenvolvimento.
3. Adicione a referência para a DLL da Bematech no seu projeto C#.
4. Compile o projeto.

## Utilização

1. Inclua os namespaces necessários no seu código:
   ```csharp
   using System;
   using System.Runtime.InteropServices;
