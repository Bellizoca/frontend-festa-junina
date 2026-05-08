<script>
    // Seus dados
    const categorias = [
        {id: 1, nome: "Clássicos" },
        {id: 2, nome: "Especiais" },
        {id: 3, nome: "Bebidas" },
        {id: 4, nome: "Caixas" },
    ];

    const produtos = [ 
        { categoriaId: 1, nome: "Glazed Original", descricao: "Cobertura de glacê clássico e leve", preco: 8.00, imagem: "https://natashaskitchen.com" },
        { categoriaId: 1, nome: "Chocolate Intenso", descricao: "Cobertura de chocolate belga com granulado", preco: 9.50, imagem: "https://gstatic.com" },
        { categoriaId: 1, nome: "Morango com Creme", descricao: "Recheio de chantilly e cobertura de morango", preco: 10.00, imagem: "https://gstatic.com" },
        { categoriaId: 2, nome: "Red Velvet", descricao: "Massa aveludada vermelha com cream cheese", preco: 13.00, imagem: "https://gstatic.com" },
        { categoriaId: 2, nome: "Unicórnio", descricao: "Cobertura colorida com glitter comestível", preco: 14.00, imagem: "https://pinimg.com" },
        { categoriaId: 3, nome: "Café Coado", descricao: "Grãos selecionados, xícara 200ml", preco: 7.00, imagem: "https://gstatic.com" },
        { categoriaId: 4, nome: "Caixa com 6", descricao: "Mix de clássicos e especiais", preco: 46.00, imagem: "https://gstatic.com" }
    ];

    const navCategorias = document.getElementById('nav-categorias');
    const listaProdutos = document.getElementById('lista-produtos');
    const categoriaTitulo = document.getElementById('categorias-titulo');

    function carregarMenu() {
        navCategorias.innerHTML = '';
        categorias.forEach(cat => {
            const btn = document.createElement('button');
            btn.className = 'btn-cat';
            btn.innerText = cat.nome;
            btn.onclick = () => selecionar(cat);
            navCategorias.appendChild(btn);
        });
        selecionar(categorias[0]); // Começa na primeira
    }

    function selecionar(categoria) {
        categoriaTitulo.innerText = categoria.nome;
        
        // Atualiza botões
        document.querySelectorAll('.btn-cat').forEach(btn => {
            btn.classList.toggle('ativa', btn.innerText === categoria.nome);
        });

        // Filtra produtos
        const filtrados = produtos.filter(p => p.categoriaId === categoria.id);
        renderizar(filtrados);
    }

    function renderizar(itens) {
        listaProdutos.innerHTML = '';
        itens.forEach(p => {
            const card = document.createElement('div');
            card.className = 'donut-card';
            card.innerHTML = `
                <img src="${p.imagem}" class="donut-img">
                <h3 class="donut-nome">${p.nome}</h3>
                <p class="donut-desc">${p.descricao || p.descrição}</p>
                <span class="donut-preco">R$ ${p.preco.toFixed(2)}</span>
                <button class="btn-adicionar">Adicionar 🛒</button>
            `;
            listaProdutos.appendChild(card);
        });
    }

    window.onload = carregarMenu;
</script>
