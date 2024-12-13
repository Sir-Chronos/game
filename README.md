# Jogo de Batalha em C#

## 📜 Descrição
Este é um jogo de batalha em português, desenvolvido em C#, onde jogadores enfrentam inimigos utilizando estratégias e habilidades. O jogo foi projetado com uma arquitetura modular e utiliza cinco padrões de projeto para melhorar a organização e escalabilidade do código.

## 🕹️ Como Jogar
1. **Selecione seu personagem**: Escolha entre diferentes classes, cada uma com habilidades e estratégias únicas.
2. **Enfrente inimigos**: Utilize ações de combate como ataque, defesa ou habilidades especiais para derrotar seus oponentes.
3. **Gerencie seu progresso**: O jogo salva automaticamente seu estado em momentos-chave, permitindo que você retome de onde parou.
4. **Objetivo**: Derrote todos os inimigos e conclua as batalhas com a pontuação mais alta possível!

## 🚀 Como Executar
1. **Pré-requisitos**: Certifique-se de ter o .NET SDK instalado. Faça o download [aqui](https://dotnet.microsoft.com/download).
2. **Clone o repositório**:
   ```bash
   git clone https://github.com/Sir-Chronos/game.git
   ```
3. **Acesse a pasta do projeto**:
   ```bash
   cd Game
   ```
4. **Acesse a pasta do jogo**:
   ```bash
   cd RPG
   ```
5. **Compile o jogo**:
   ```bash
   dotnet build
   ```
6. **Inicie o jogo**:
   ```bash
   dotnet run
   ```

## 🛠️ Funcionalidades
- Criação dinâmica de personagens (jogadores e inimigos).
- Diferentes estratégias de combate, incluindo ataques especiais.
- Sistema de notificações de eventos durante o jogo.
- Salvamento e restauração do progresso do jogador.

## 📚 Padrões de Projeto Utilizados
1. **Factory**  
   O padrão Factory foi utilizado para simplificar e centralizar a criação de personagens (jogadores e inimigos).  
   - **Exemplo**: Uma única classe responsável por criar instâncias de diferentes classes de personagens (como Guerreiro, Mago, Arqueiro) sem expor a lógica de criação para o código principal.  
   - **Benefício**: Facilita a adição de novas classes de personagens no futuro.

2. **Strategy**  
   O padrão Strategy gerencia as ações de combate dos personagens, permitindo que comportamentos como ataque, defesa e habilidades especiais sejam intercambiáveis.  
   - **Exemplo**: Cada estratégia (ataque físico, magia ou defesa) é implementada como uma classe separada, que pode ser atribuída dinamicamente ao personagem.  
   - **Benefício**: Reduz o acoplamento e facilita a introdução de novas estratégias ou ajustes nas existentes.

3. **Observer**  
   Utilizado para notificar o jogador sobre eventos importantes durante o jogo, como alterações na vida dos personagens ou status da batalha.  
   - **Exemplo**: Uma classe "Gerenciador de Eventos" observa mudanças no estado de vida de personagens e dispara notificações visuais ou sonoras para o jogador.  
   - **Benefício**: Promove a comunicação entre componentes do jogo sem criar dependências diretas entre eles.

4. **Singleton**  
   Este padrão foi usado para gerenciar o estado global do jogo, como pontuação, status geral e configurações.  
   - **Exemplo**: Uma classe "Gerenciador do Jogo" acessada globalmente mantém o controle do progresso do jogador, garantindo que exista apenas uma instância dessa classe.  
   - **Benefício**: Centraliza o gerenciamento de informações globais e impede a criação de múltiplas instâncias desnecessárias.

5. **Memento**  
   O padrão Memento foi implementado para salvar e restaurar estados do jogo, permitindo que o jogador retome de pontos específicos.  
   - **Exemplo**: O jogo salva o estado de vida, posição e status dos personagens em momentos-chave e permite restaurar caso o jogador queira voltar.  
   - **Benefício**: Proporciona flexibilidade e segurança no avanço do jogo, evitando perdas de progresso.

## 📽️ Vídeo do Projeto
   - [Vídeo Apresentação](https://drive.google.com/file/d/1_5hsEQsQuocoQXKVQJuxWCJ0jrEgCGka/view?usp=sharing)


## ✨ Autores
Desenvolvido por **Luana**, **Kelvin** e **Gabriel Teodoro**
