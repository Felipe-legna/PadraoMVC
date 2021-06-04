
// Write your Javascript code.
$(document).ready(function () {
    $("#listaDeModelos tr").click(function () {        
        var id = $(this).find(".id").html();
        var quantidadePecas = $(this).find(".quantidadePecas").html();

        $("#pecas").empty();
        adicionarPecas(quantidadePecas);

        $('#modelBancada').modal('toggle');
    });

    $("#adicionarBancada").click(function () {
        var frontao = $("#frontao").val();
        var saia = $("#saia").val();
              
        //para a quantidade de peças, obter valores de comprimento e largura.
        var peca1 = $("#peca1 .comprimento").val();

        var t = "";
    });
    
})

function adicionarPecas(quantidadePecas) {
    var pecas = "";
    for (var i = 0; i < quantidadePecas; i++) {
        pecas = '<div id="peca'+(i+1)+'" class="row">' + addInput('Peça - ' + (i + 1) + ' Comprimento:', 'comprimento', 6) + ' ' + addInput('Peça - ' + (i + 1) +' Largura:', 'largura', 6) +'</div>';
    }

    $("#pecas").append(pecas);
}


function addInput(nomeHtml, classe, tamanhoColuna) {
    var input = '<div class="col-sm-' + tamanhoColuna + '"><div class="form-group"><label for="inputsm">' + nomeHtml + '</label><input class="form-control input-sm ' + classe + '" type="text" value=""></div></div>';
    return input;
}

