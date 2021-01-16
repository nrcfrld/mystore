$(document).ready(function () {

    'use strict';

    $("#gambar").on("change", function () {
        var filename = $(this).val().split("\\").pop();
        console.log(filename);
        $(this).siblings(".custom-file-label").addClass("selected").html(filename);
    });

    $('#tblproduk').DataTable({
        "iDisplayLength": 5,
        "lengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
        "dom": 'Bfrtip',
        "buttons": [
            {
                text: 'Tambah Data',
                action: function (e, dt, node, config) {
                    $("#addProdukModal").modal("show");
                }
            },
            {
                extend: 'excelHtml5',
                title: 'Data Produk ',
                exportOptions: {
                    columns: "thead th:not(.noExport)"
                }
            },
            {
                extend: 'copyHtml5',
                title: 'Data Produk ',
                exportOptions: {
                    columns: "thead th:not(.noExport)"
                }
            },
            {
                extend: 'csvHtml5',
                title: 'Data Produk ',
                exportOptions: {
                    columns: "thead th:not(.noExport)"
                }
            },
            {
                extend: 'pdfHtml5',
                title: 'Data Produk ',
                exportOptions: {
                    columns: "thead th:not(.noExport)"
                }
            }
        ],
        select: true
    });

    // End Untuk Dashboard Produk
    var otable;

    otable = $('#tbl-transheader').dataTable({
        "iDisplayLength": 5,
        "lengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
        "dom": 'Bfrtip',
        "buttons": [
            {
                text: 'Tambah Data',
                action: function (e, dt, node, config) {
                    $("#addTransaksiModal").modal("show");
                }
            }
        ]
    });

    $('#tbltransaksi tbody td img').click(function () {
        var nTr = this.parentNode.parentNode;
        var transid = $(this).attr("rel");  
        if (this.src.match('details_close')) {   
            this.src = "/Content/Dashboard/img/details_open.png";
            otable.fnClose(nTr); 
        } else {   
            this.src = "/Content/Dashboard/img/details_close.png";
            var url = "Transaksi/ResultDetailView/" + transid;
            $.get(url, '', function (details) { 
                otable.fnOpen(nTr, details, 'details');
            });

        }
    });

    var otable;
   
    $('#tbl-transheader tbody td img').click(function () {
        console.log(otable);
        var nTr = this.parentNode.parentNode;
        var transid = $(this).attr("rel");
        console.log(transid)    
        if (this.src.match('details_close')) {
            this.src = "/Content/Dashboard/img/details_open.png";
            otable.fnClose(nTr);
        } else {
            this.src = "/Content/Dashboard/img/details_close.png";
            var url = "Transaksi/ResultDetailView/" + transid;
            $.get(url, '', function (details) {
                otable.fnOpen(nTr, details, 'details');
            });

        }
    });

    $("#transproduk").change(function () {
        var id = $(this).val();
        $.ajax({
            url: 'Transaksi/getHargaProduk/' + id,
            type: 'get',
            dataType: 'json',
            success: function (response) {
                var len = response.length;

                $("#transharga").empty();
                $("#lbltransharga").empty();
                $("#lbltransharga").val(response['harga']);
                $("#transharga").val(response['harga']);
            }
        });
    });

    

    // ------------------------------------------------------- //
    // Search Box
    // ------------------------------------------------------ //
    $('#search').on('click', function (e) {
        e.preventDefault();
        $('.search-box').fadeIn();
    });
    $('.dismiss').on('click', function () {
        $('.search-box').fadeOut();
    });

    // ------------------------------------------------------- //
    // Card Close
    // ------------------------------------------------------ //
    $('.card-close a.remove').on('click', function (e) {
        e.preventDefault();
        $(this).parents('.card').fadeOut();
    });

    // ------------------------------------------------------- //
    // Tooltips init
    // ------------------------------------------------------ //    

    $('[data-toggle="tooltip"]').tooltip()    


    // ------------------------------------------------------- //
    // Adding fade effect to dropdowns
    // ------------------------------------------------------ //
    $('.dropdown').on('show.bs.dropdown', function () {
        $(this).find('.dropdown-menu').first().stop(true, true).fadeIn();
    });
    $('.dropdown').on('hide.bs.dropdown', function () {
        $(this).find('.dropdown-menu').first().stop(true, true).fadeOut();
    });


    // ------------------------------------------------------- //
    // Sidebar Functionality
    // ------------------------------------------------------ //
    $('#toggle-btn').on('click', function (e) {
        e.preventDefault();
        $(this).toggleClass('active');

        $('.side-navbar').toggleClass('shrinked');
        $('.content-inner').toggleClass('active');
        $(document).trigger('sidebarChanged');

        if ($(window).outerWidth() > 1183) {
            if ($('#toggle-btn').hasClass('active')) {
                $('.navbar-header .brand-small').hide();
                $('.navbar-header .brand-big').show();
            } else {
                $('.navbar-header .brand-small').show();
                $('.navbar-header .brand-big').hide();
            }
        }

        if ($(window).outerWidth() < 1183) {
            $('.navbar-header .brand-small').show();
        }
    });

    // ------------------------------------------------------- //
    // Universal Form Validation
    // ------------------------------------------------------ //

    $('.form-validate').each(function() {  
        $(this).validate({
            errorElement: "div",
            errorClass: 'is-invalid',
            validClass: 'is-valid',
            ignore: ':hidden:not(.summernote, .checkbox-template, .form-control-custom),.note-editable.card-block',
            errorPlacement: function (error, element) {
                // Add the `invalid-feedback` class to the error element
                error.addClass("invalid-feedback");
                console.log(element);
                if (element.prop("type") === "checkbox") {
                    error.insertAfter(element.siblings("label"));
                } 
                else {
                    error.insertAfter(element);
                }
            }
        });

    });    

    // ------------------------------------------------------- //
    // Material Inputs
    // ------------------------------------------------------ //

    var materialInputs = $('input.input-material');

    // activate labels for prefilled values
    materialInputs.filter(function() { return $(this).val() !== ""; }).siblings('.label-material').addClass('active');

    // move label on focus
    materialInputs.on('focus', function () {
        $(this).siblings('.label-material').addClass('active');
    });

    // remove/keep label on blur
    materialInputs.on('blur', function () {
        $(this).siblings('.label-material').removeClass('active');

        if ($(this).val() !== '') {
            $(this).siblings('.label-material').addClass('active');
        } else {
            $(this).siblings('.label-material').removeClass('active');
        }
    });

    // ------------------------------------------------------- //
    // Footer 
    // ------------------------------------------------------ //   

    var contentInner = $('.content-inner');

    $(document).on('sidebarChanged', function () {
        adjustFooter();
    });

    $(window).on('resize', function () {
        adjustFooter();
    })

    function adjustFooter() {
        var footerBlockHeight = $('.main-footer').outerHeight();
        contentInner.css('padding-bottom', footerBlockHeight + 'px');
    }

    // ------------------------------------------------------- //
    // External links to new window
    // ------------------------------------------------------ //
    $('.external').on('click', function (e) {

        e.preventDefault();
        window.open($(this).attr("href"));
    });

    // ------------------------------------------------------ //
    // For demo purposes, can be deleted
    // ------------------------------------------------------ //

    var stylesheet = $('link#theme-stylesheet');
    $("<link id='new-stylesheet' rel='stylesheet'>").insertAfter(stylesheet);
    var alternateColour = $('link#new-stylesheet');

    if ($.cookie("theme_csspath")) {
        alternateColour.attr("href", $.cookie("theme_csspath"));
    }

    $("#colour").change(function () {

        if ($(this).val() !== '') {

            var theme_csspath = 'css/style.' + $(this).val() + '.css';

            alternateColour.attr("href", theme_csspath);

            $.cookie("theme_csspath", theme_csspath, {
                expires: 365,
                path: document.URL.substr(0, document.URL.lastIndexOf('/'))
            });

        }

        return false;
    });

});