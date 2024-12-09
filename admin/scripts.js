Array.from(document.getElementsByClassName('search-btn')).forEach(function (element) {
    element.addEventListener('click', function () {
        this.parentElement.classList.toggle('open')
        this.previousElementSibling.focus();
    });
    element.previousElementSibling?.addEventListener('input', function () {
        const text = this.value; // Get the value of the previous element (assumed to be an input)
        const link = this.getAttribute('data-target'); // Get the data-target attribute
        // AJAX request or any action
    });
    
});


document.addEventListener("DOMContentLoaded", () => {
    // Lấy tất cả các thẻ li và div content-section
    const listItems = document.querySelectorAll(".new-list li");
    const mainContent = document.querySelectorAll(".body-card > .main");

    // Ẩn tất cả các div .main
    const hideAllSections = () => {
        mainContent.forEach(section => {
            section.style.display = "none";
        });
    };

    // Thêm sự kiện click vào từng li
    listItems.forEach(item => {
        item.addEventListener("click", () => {
            // Lấy giá trị data-target của li được click
            const target = item.getAttribute("data-target");

            // Ẩn tất cả các div
            hideAllSections();

            // Hiển thị div có liên quan
            const sectionToShow = document.querySelector(`.body-card > .main[data-section="${target}"]`);
            if (sectionToShow) {
                sectionToShow.style.display = "block";
            }
        });
    });

    // Hiển thị mặc định nội dung của li đầu tiên (Dashboard)
    hideAllSections();
    const defaultSection = document.querySelector(`.body-card > .main[data-section="dashboard"]`);
    if (defaultSection) {
        defaultSection.style.display = "block";
    }
});


//ffun-nha
$(document).ready(function () {
    // Hide add product form when cancel button is clicked
    $('.bi-plus').click(function () {
        if ($('.add-product').hasClass('d-none')) {
            $('.title-product').addClass('d-none');  // Hide the table
            $('.table-product').addClass('d-none');  // Hide the table
            $('.bi-list').removeClass('d-none');
            $('.title-product-add').removeClass('d-none');
            $('.add-product').removeClass('d-none');
            $('.bi-plus').addClass('d-none');  // Hide the table
        }
    });
    $('.bi-list').click(function () {
        $('.title-product').removeClass('d-none');
        $('.table-product').removeClass('d-none');
        $('.title-product-add').addClass('d-none');
        $('.add-product').addClass('d-none');
        $('.bi-plus').removeClass('d-none');
        $('.bi-list').addClass('d-none');
        
    });
});

function displayImages(input) {
    const fileList = input.files;  // Get the list of selected files
    const previewContainer = document.getElementById('imagePreviewContainer');
    previewContainer.innerHTML = '';  // Clear any previous previews

    // Loop through all files and create image previews and file paths
    for (let i = 0; i < fileList.length; i++) {
        const file = fileList[i];

        // Create a container for each image and its path
        const imageContainer = document.createElement('div');
        imageContainer.classList.add('image-preview-item');
        imageContainer.style.marginBottom = '15px';

        // Create an image element
        const img = document.createElement('img');
        img.classList.add('image-preview');
        img.file = file;

        // Create a file path element
        const path = document.createElement('span');
        path.classList.add('image-path');
        path.textContent = file.name;

        // Create a FileReader to display the image
        const reader = new FileReader();
        reader.onload = function (e) {
            img.src = e.target.result;  // Set the image source to the reader's result
        };
        reader.readAsDataURL(file);  // Read the file as a data URL

        // Append the image and path to the container
        imageContainer.appendChild(img);
        imageContainer.appendChild(path);

        // Append the container to the preview container
        previewContainer.appendChild(imageContainer);
    }
}
/* Brand Management*/ 
document.addEventListener("DOMContentLoaded", function () {
    const brandAddButton = document.querySelector(".brand-btn"); // Nút "+" để thêm brand
    const brandAddForm = document.querySelector(".add-brand"); // Form nhập brand
    const titleBrandAdd = document.querySelector(".title-brand-add"); // Tiêu đề "Add Brand"
    const titleBrand = document.querySelector(".title-brand"); // Tiêu đề "Brand Management"
    const closeButton = document.querySelector(".close-btn"); // Nút đóng form

    // Khi nhấn nút "+" (thêm brand), kiểm tra trạng thái của form
    brandAddButton.addEventListener("click", function () {
        // Kiểm tra xem form đã hiển thị chưa
        if (brandAddForm.classList.contains("d-none")) {
            // Nếu form chưa hiển thị, hiển thị form và thay đổi tiêu đề
            titleBrand.classList.add("d-none"); // Ẩn tiêu đề Brand Management
            titleBrandAdd.classList.remove("d-none"); // Hiển thị tiêu đề Add Brand
            brandAddForm.classList.remove("d-none"); // Hiển thị form thêm brand
            closeButton.classList.remove("d-none"); // Hiển thị nút quay lại
        } else {
            // Nếu form đã hiển thị, ẩn form và thay đổi tiêu đề
            titleBrand.classList.remove("d-none"); // Hiển thị lại tiêu đề Brand Management
            titleBrandAdd.classList.add("d-none"); // Ẩn tiêu đề Add Brand
            brandAddForm.classList.add("d-none"); // Ẩn form thêm brand
            closeButton.classList.add("d-none"); // Ẩn nút quay lại
        }
    });

    // Khi nhấn nút "Back to Brand List", sẽ quay lại màn hình quản lý
    closeButton.addEventListener("click", function () {
        titleBrand.classList.remove("d-none"); // Hiển thị lại tiêu đề Brand Management
        titleBrandAdd.classList.add("d-none"); // Ẩn tiêu đề Add Brand
        brandAddForm.classList.add("d-none"); // Ẩn form thêm brand
        closeButton.classList.add("d-none"); // Ẩn nút quay lại
    });
});


