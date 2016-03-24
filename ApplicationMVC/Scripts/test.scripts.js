$(function () {

    function setAutocomplete() {
        var $input = $(this);

        var options = {
            source: $input.data('test-autocomplete')
        }

        $input.autocomplete(options);
    }

    function loadItems() {
        var $table = $('#test-items-list');

        var actionUrl = $table.data('action-url');
        var displayedItems = $table.find('tr').length - 1;
        var itemsToFetch = displayedItems + 10;

        var options = {
            url: actionUrl,
            data: {
                take: itemsToFetch
            }
        }

        $.ajax(options).done(function (data) {
            $table.html(data);
        });
    }

    $('input[data-test-autocomplete]').each(setAutocomplete);
    $('#load-items-button').on('click', loadItems);
})