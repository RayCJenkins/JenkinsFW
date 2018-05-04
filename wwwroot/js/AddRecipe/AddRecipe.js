var HookupRemoveClick = function(){
    $('span.remove-ingredient').off('click');
    $('span.remove-ingredient').on('click',function(){
        $(this).closest('div').remove();
    });
};
$('.add-ingredient').on('click', function(){
    var el = document.createElement('div');
    el.setAttribute("class", "ingredient");
    $(el).html('<input class="ingredient-name"/><input class="ingredient-amount"/><span class="remove-ingredient clickable">x</span>');
    $('div.ingredient-list').append(el);
    HookupRemoveClick();
});
$('#savebutton').on('click', function(){
    var title = $('#Title').val();
    var description = $('#Description').val();
    var preptime = $('#PrepTime').val();
    var cooktime = $('#CookTime').val();
    var servings = $('#Servings').val();
    var instructions = $('#Instructions').val();
    var ingredients = $('.ingredient').map(function(){
        return {
            Name: $(this).find('.ingredient-name').val(),
            Amount: $(this).find('.ingredient-amount').val()
        };
    }).toArray();
    var postData = {
        title: title,
        description: description,
        prepTime: preptime,
        cookTime: cooktime,
        servings: servings,
        instructions: instructions,
        ingredients: ingredients
    };
    
    $.ajax(
        {
            url:'/addrecipe/saverecipe',
            type: 'POST',
            contentType: 'application/json; charset=UTF-8',
            data: JSON.stringify(postData),
            beforeSend: function(){
                alert('BeforeSend:'+JSON.stringify(postData));
            },
            success: function(response){
                alert('Success: '+response);
            },
            error: function(response){
                alert('Error: '+response);
            }
        }
    )
});
