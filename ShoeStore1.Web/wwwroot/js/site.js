$(document).ready(function () {
    if (window.CurrentUser) {
        LoadUserCart();
    }



    $('#btnFilter').click(function () {
        debugger;
        let selectedCategories = [];
        $('.filter-category:checked').each(function () {
            selectedCategories.push($(this).val());
        });

        let MinPrice = $('#minPrice').val();
        let MaxPrice = $('#maxPrice').val();
        let filterData = {
            categories: selectedCategories,
            MinPrice: MinPrice ? MinPrice : 0,
            MaxPrice: MaxPrice ? MaxPrice : 9999999
        };
        $('#listTitle').text("Filtrelenmiş Ürünler");
        $('#productListArea').html('<div class="col-12 text-center mt-5"><div class="spinner-border text-primary" role="status"></div></div>');

        $.ajax({
            url: "/api/ProductApi/FilterProducts",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(filterData),
            success: function (data) {

                renderProduct(data);
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
});



function LoadUserCart() {
    $.ajax({
        url: `/api/CartApi/GetUserCart/${window.CurrentUser.Id}`,
        type: "GET",
        success: function (data) {
            updateCart(data);
        },
        error: function (err) {
            console.log(err);
        }
    });

}

function updateCart(cart) {
    $('#cartItemCount').text(cart.totalItems);
    let $cartDropdownMenu = $('#cartDropdown').next('.dropdown-menu');
    $cartDropdownMenu.empty();

    if (cart.totalItems == 0) {
        $cartDropdownMenu.append('<li class="p-3 text-center text-muted">Sepetinizde ürün bulunmamaktadır.</li>');
        return;
    }

    $.each(cart.items, function (index, item) {
        let htmlItem = `
        <li>
            <div class="dropdown-item d-flex justify-content-between align-items-center">
                <div>
                    <h6 class="my-0">${item.productName}</h6>
                    <small class="text-muted">Numara: ${item.size} | Adet: ${item.quantity}</small>
                </div>
                <div class="d-flex align-items-center gap-2">
                    <span class="text-success fw-bold">${item.price} ₺</span>

                    <button type="button"
                            class="btn btn-sm btn-outline-danger btn-delete-cart"
                            data-id="${item.id}">×
                    </button>
                </div>
            </div>
        </li>`;
        $cartDropdownMenu.append(htmlItem);
    });

    $cartDropdownMenu.append('<li><hr class="dropdown-divider"></li>');

    $cartDropdownMenu.append(`
            <li>
                 <div class="dropdown-item d-flex justify-content-between">
                    <strong>Ara Toplam:</strong>
                    <strong>${cart.totalPrice} ₺</strong>
                 </div>
            </li>
    `);
    $cartDropdownMenu.append(`
            <li class="p-2">
                 <a href="/Cart" class="btn btn-primary w-100">Sepete Git / Öde</a>
            </li>
    `);
}

function renderProduct(data) {
    let $area = $('#productListArea');
    $area.empty();

    if (data.length == 0) {
        $area.append('<div class="col-12 text-muted text-center mt-4"><h5>Bu kriterlere uygun ürün bulunamadı.</h5></div>');
        return;
    }

    $.each(data, function (index, item) {
        let sizeOptions = '<option value="">Numara Seçin</option>';
        if (item.sizes && item.sizes.length > 0) {
            $.each(item.sizes, function (i, size) {
                sizeOptions += `<option value="${size}">${size}</option>`;
            });
        }

        let cartHtml = `
                <div class="col">
                    <div class="card h-100 shadow-sm border-0 product-card">
                        <img src="${item.imageUrl}" class="card-img-top p-3 rounded-4" alt="${item.name}" style="height: 200px; object-fit: contain;">
                        <div class="card-body d-flex flex-column pt-0">
                            <span class="badge bg-light text-dark mb-2 align-self-start border">${item.category}</span>
                            <h6 class="card-title text-truncate" title="@item.Name">${item.name}</h6>
                            <h5 class="card-text text-primary fw-bold pb-2">${item.price} ₺</h5>

                            <!-- Numara Seçim Dropdown -->
                            <div class="mb-2 mt-auto">
                                <select class="form-select form-select-sm border-secondary" id="size-${item.id}">
                                    ${sizeOptions}
                                </select>
                            </div>

                            <!-- Sepete Ekle Butonu -->
                            <div class="d-grid gap-2">
                                <button class="btn btn-outline-primary btn-sm btn-add-cart" data-id="${item.id}">
                                    🛒 Sepete Ekle
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
        `;
        $area.append(cartHtml);

    });
}

// Sepete Ekleme Butonu Click Event
$(document).on('click', '.btn-add-cart', function (e) {

    // Check if the user is logged in
    if (!window.CurrentUser) {
        alert("Sepete ürün eklemek için önce giriş yapmalısınız.");
        window.location.href = "/Account/Login";
        return;
    }
    let $btn = $(this);
    let productId = $btn.data("id"); // data-id="${item.id}

    let $sizeSelect = $(`#size-${productId}`); //id="size-${item.id}
    let selectedSize = $sizeSelect.val();

    // Check if a size is selected
    if (!selectedSize) {
        alert("Lütfen önce bir numara seçiniz.");
        $sizeSelect.focus();
        return;
    }

    let originalBtn = $btn.html(); // orjinal butonu aldık

    $btn.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Ekleniyor...'); // butonun içeriğini değiştiriyoruz
    $btn.prop('disabled', true); // butonu devre dışı bırakıyoruz


    var cartData = {
        cartId: 0,
        productId: productId,
        size: selectedSize,
        userId: `${window.CurrentUser.Id}` 
    }

    $.ajax({
        url: '/api/CartApi/SetCart',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(cartData),
        success: function (res) {
            LoadUserCart();

            $btn.html('✅ Eklendi');
            $btn.removeClass('btn-outline-primary').addClass('btn-success');

            setTimeout(function () {
                $btn.html(originalBtn);
                $btn.removeClass('btn-success').addClass('btn-outline-primary');
                $btn.prop('disabled', false);

            }, 2000);
        },
        error: function (err) {
            console.log(err);
            $btn.html(originalBtn);
            $btn.prop('disabled', false);
        }

    });


});
$(document).on('click', '.btn-delete-cart', function () {
    debugger;
    let cartItemId = $(this).data('id');

    //console.log("Silinecek CartItem Id:", cartItemId);

    $.ajax({
        url: '/api/CartApi/DeleteCartItem',
        type: 'POST', 
        contentType: 'application/json',
        data: JSON.stringify(cartItemId),
        success: function () {
            //console.log("Silme başarılı");
            LoadUserCart();            
        },
        error: function (err) {
            console.log("Silme hatası:", err);
        }
    });

});


