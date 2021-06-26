

// Write your Javascript code.
var quantidadePecas = 0;
var metodo = "";
var categoria = "";
var errors = [];

var bancadaId = "";
var materialId = "";
var metroQuadrado = "";
var valorBancada = 0;


$(document).ready(function () {

    $("#nav-material-tab").addClass("disabled");

    $("#listaDeModelos tr").click(function () {
        bancadaId = $(this).find(".id").html();
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
            requisicao("POST", data, "criar-bancada", liberarTabMaterial);
        }
    });


    $('.dataTable').DataTable({
        //"scrollY": "200px",
        //"scrollCollapse": true,
        //"paging": false,
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.25/i18n/Portuguese-Brasil.json'
        }
    });


    $("#material").change(function () {
        materialId = $(this).val();
        metroQuadrado = $("#metroQuadrado").val();
        calcularValorBancada(materialId, metroQuadrado);
    });

    $("#adicionarBancadaOrcamento").click(function () {    

       
        adicionarBancadaOrcamento(bancadaId, materialId, metroQuadrado, valorBancada);
        $('#modelBancada').modal('hide');
    });

})


function adicionarBancadaOrcamento(bancadaId, materialId, metroQuadrado, valorBancada) {
    var data = { "bancadaid": bancadaId, "materialId": materialId, "metroQuadrado": metroQuadrado, "valor": exb(valorBancada) };
    requisicao("POST", data, "adicionar-bancada", liberarTabMaterial);
}

function adicionarPecas(quantidadePecas) {
    var pecas = "";
    for (var i = 0; i < quantidadePecas; i++) {
        pecas += '<div id="peca' + (i + 1) + '" class="row">' + addInput('Peça - ' + (i + 1) + ' Comprimento:', 'comprimento', 6) + ' ' + addInput('Peça - ' + (i + 1) + ' Largura:', 'largura', 6) + '</div>';
    }

    $("#pecas").append(pecas);
}

function liberarTabMaterial(dados) {
    exibirCarregando(false);
    $("#nav-material-tab").removeClass("disabled");

    $("#metroQuadrado").val(exb(dados.metroQuadrado));
}

function calcularValorBancada(idMaterial, metroQuadrado) {
    if (idMaterial != "") {
        var data = { "materialid": idMaterial, "metroquadrado": metroQuadrado };
        requisicao("GET", data, "calcular-valor-bancada", calcularValorBancada_callback);
    }
}

function calcularValorBancada_callback(dados) {
    exibirCarregando(false);
    valorBancada = dados;
    $("#valorBancada").val(valorBancada);
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
    else if (campo != "Frontão" && campo != "Saia") {
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
