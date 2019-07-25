$(function(){
    $('button').click(function(){
        var url='data:application/vnd.ms-excel,' + encodeURIComponent($('#descargaTabla').html()) 
        location.href=url
        return false
    })
})