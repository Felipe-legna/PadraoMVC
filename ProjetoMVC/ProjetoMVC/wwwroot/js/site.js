

// Write your Javascript code.
var quantidadePecas = 0;
var metodo = "";
var categoria = "";
var errors = [];

$(document).ready(function () {
    $("#listaDeModelos tr").click(function () {
        var id = $(this).find(".id").html();
        quantidadePecas = $(this).find(".quantidadePecas").html();
        metodo = $(this).find(".metodo").html();
        categoria = $(this).find(".categoria").html();

        $("#pecas").empty();
        adicionarPecas(quantidadePecas);

        $('#modelBancada').modal('toggle');
    });

    $("#adicionarBancada").click(function () {
        errors = [];

        var frontao = validarNumero("Frontão", cnt($("#frontao").val()));
        var saia = validarNumero("Saia", cnt($("#saia").val()));

        //para a quantidade de peças, obter valores de comprimento e largura.
        var pecas = [];

        for (var i = 0; i < quantidadePecas; i++) {

            var largura = validarNumero("Largura", cnt($("#peca" + (i + 1) + " .largura").val()));
            var comprimento = validarNumero("Comprimento", cnt($("#peca" + (i + 1) + " .comprimento").val()));

            var peca = { "largura": exb(largura), "comprimento": exb(comprimento) };
            pecas.push(peca);
        }

        if (errors.length > 0)
            swal("Ops!", errors, "error");
        else {
            var data = { "categoria": categoria, "metodo": metodo, "frontao": exb(frontao), "saia": exb(saia), "pecasViewModel": pecas };
            requisicao("POST", data, "adicionar-bancada", adicionarMaterial);
        }
    });


    $('.dataTable').DataTable({
        //"scrollY": "200px",
        //"scrollCollapse": true,
        "paging": true,
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.25/i18n/Portuguese-Brasil.json'
        }
    });

})

    

function adicionarPecas(quantidadePecas) {
    var pecas = "";
    for (var i = 0; i < quantidadePecas; i++) {
        pecas += '<div id="peca' + (i + 1) + '" class="row">' + addInput('Peça - ' + (i + 1) + ' Comprimento:', 'comprimento', 6) + ' ' + addInput('Peça - ' + (i + 1) + ' Largura:', 'largura', 6) + '</div>';
    }

    $("#pecas").append(pecas);
}

function adicionarMaterial(dados) {
    //var objeto = JSON.stringify(dados);
    var metroQuadrado = dados.metroQuadrado;

    //to-do 
    // Adicionar a peça no coockie

    calcularValorPeca(metroQuadrado)
}

function calcularValorPeca(metroQuadrado) {

}

function addInput(nomeHtml, classe, tamanhoColuna) {
    var input = '<div class="col-sm-' + tamanhoColuna + '"><div class="form-group"><label for="inputsm">' + nomeHtml + '</label><input class="form-control input-sm ' + classe + '" type="text" value=""></div></div>';
    return input;
}


function validarNumero(campo, numero) {

    if (numero != "") {
        if (isNaN(numero)) {
            errors.push("O campo " + campo + " deve ser um número.\n");
            return;
        } else if (numero < 0) {
            errors.push("O campo " + campo + " deve ser maior ou igual a zero.\n");
            return;
        }

    }
    else if (campo != "Frontão" && campo != "Saia")
    {
        errors.push("O campo " + campo + " é obrigatório.\n");
        return;
    }
    return numero;
}


function cnt(numero) {
    if (isNaN(numero))
        return parseFloat(numero.replace(',', '.'));
    else
        return parseFloat(numero);
}

function exb(numero) {
    if (numero == null)
        return 0;
    return numero.toLocaleString('pt-br', { minimumFractionDigits: 2 });
}

function requisicao(tipo, data, metodo, metodoCallback) {

    $.ajax({
        type: tipo,
        url: "/Home/" + metodo,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        dataType: 'json',
        data: data,
        beforeSend: function () {
            exibirCarregando(true);
        },
        error: function (response) {
            swal("Ops!", "Erro. Verifique os dados fonte.", "error");
            exibirCarregando(false);
        }

    }).done(function (response) {
        metodoCallback(response);
    });
}


function exibirCarregando(opcao) {
    if (opcao) {
        $("#carregando").show();
        $("body").css('opacity', '0.6');
        $(".btn").prop("disabled", true);
    }
    else {
        $("#carregando").hide();
        $("body").css('opacity', '1');
        $(".btn").prop("disabled", false);
    }
}
