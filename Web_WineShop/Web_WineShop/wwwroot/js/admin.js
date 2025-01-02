Array.from(document.getElementsByClassName("search-btn")).forEach(function (
  element
) {
  element.addEventListener("click", function () {
    this.parentElement.classList.toggle("open");
    this.previousElementSibling.focus();
  });
  element.previousElementSibling?.addEventListener("input", function () {
    const text = this.value; // Get the value of the previous element (assumed to be an input)
    const link = this.getAttribute("data-target"); // Get the data-target attribute
    // AJAX request or any action
  });
});

document.addEventListener("DOMContentLoaded", () => {
  // Lấy tất cả các thẻ li và div content-section
  const listItems = document.querySelectorAll(".new-list li");
  const mainContent = document.querySelectorAll(".body-card > .main");

  // Ẩn tất cả các div .main
  const hideAllSections = () => {
    mainContent.forEach((section) => {
      section.style.display = "none";
    });
  };

  // Thêm sự kiện click vào từng li
  listItems.forEach((item) => {
    item.addEventListener("click", () => {
      // Lấy giá trị data-target của li được click
      const target = item.getAttribute("data-target");

      // Ẩn tất cả các div
      hideAllSections();

      // Hiển thị div có liên quan
      const sectionToShow = document.querySelector(
        `.body-card > .main[data-section="${target}"]`
      );
      if (sectionToShow) {
        sectionToShow.style.display = "block";
      }
    });
  });

  // Hiển thị mặc định nội dung của li đầu tiên (Dashboard)
  hideAllSections();
  const defaultSection = document.querySelector(
    `.body-card > .main[data-section="dashboard"]`
  );
  if (defaultSection) {
    defaultSection.style.display = "block";
  }
});

$(document).ready(function () {
  // Hide add product form when cancel button is clicked
  $(".bi-plus-admin").click(function () {
    if ($(".add-items").hasClass("d-none")) {
      $(".title-items").addClass("d-none"); // Hide the table
      $(".table-items").addClass("d-none"); // Hide the table
      $(".bi-list-admin").removeClass("d-none");
      $(".title-items-add").removeClass("d-none");
      $(".add-items").removeClass("d-none");
      $(".bi-plus-admin").addClass("d-none"); // Hide the table
    }
  });
  $(".bi-list-admin").click(function () {
    $(".title-items").removeClass("d-none");
    $(".table-items").removeClass("d-none");
    $(".title-items-add").addClass("d-none");
    $(".add-items").addClass("d-none");
    $(".bi-plus-admin").removeClass("d-none");
    $(".bi-list-admin").addClass("d-none");
  });
});

function displayImages(input) {
  const fileList = input.files; // Get the list of selected files
  const previewContainer = document.getElementById("imagePreviewContainer");
  previewContainer.innerHTML = ""; // Clear any previous previews

  // Loop through all files and create image previews and file paths
  for (let i = 0; i < fileList.length; i++) {
    const file = fileList[i];

    // Create a container for each image and its path
    const imageContainer = document.createElement("div");
    imageContainer.classList.add("image-preview-item");
    imageContainer.style.marginBottom = "15px";

    // Create an image element
    const img = document.createElement("img");
    img.classList.add("image-preview");
    img.file = file;

    // Create a file path element
    const path = document.createElement("span");
    path.classList.add("image-path");
    path.textContent = file.name;

    // Create a FileReader to display the image
    const reader = new FileReader();
    reader.onload = function (e) {
      img.src = e.target.result; // Set the image source to the reader's result
    };
    reader.readAsDataURL(file); // Read the file as a data URL

    // Append the image and path to the container
    imageContainer.appendChild(img);
    imageContainer.appendChild(path);

    // Append the container to the preview container
    previewContainer.appendChild(imageContainer);
  }
}


// voucher hover me
document.addEventListener("DOMContentLoaded", function () {
  var popoverTriggerList = [].slice.call(
    document.querySelectorAll('[data-bs-toggle="popover"]')
  );
  popoverTriggerList.forEach(function (popoverTriggerEl) {
    new bootstrap.Popover(popoverTriggerEl, {
      trigger: "hover", // Hoặc 'click'
    });
  });
});
// Voucher add voucher
$(document).ready(function () {
  // Khi nút "plus" được nhấn
  $(".bi-plus").click(function () {
    if ($(".add-items").hasClass("d-none")) {
      $(".table-items").addClass("d-none");
      $(".bi-list").removeClass("d-none");
      $(".add-items").removeClass("d-none");
      $(".bi-plus").addClass("d-none");
    }
  });

  // Khi nút "list" được nhấn
  $(".bi-list").click(function () {
    $(".table-items").removeClass("d-none");
    $(".add-items").addClass("d-none");
    $(".bi-plus").removeClass("d-none");
    $(".bi-list").addClass("d-none");
  });
});

// solving order btn xac nhan

// solving order btn list product
document.addEventListener("DOMContentLoaded", function () {
  const popover = new bootstrap.Popover(
    document.getElementById("productPopover"),
    {
      html: true,
    }
  );
});
//////////////////////////////////////////////////////////////////////////////////////////////////
//document.addEventListener("DOMContentLoaded", function () {
//    const editButtons = document.querySelectorAll(".edit-btn");
//    const userForm = document.querySelector(".edit-user-form");

//    editButtons.forEach((btn) => {
//        btn.addEventListener("click", function () {
//            const row = this.closest("tr");
//            const userId = row.getAttribute("data-id");

//            // Lấy dữ liệu từ hàng và điền vào form
//            const fullName = row.cells[1].textContent.trim();
//            const phone = row.cells[2].textContent.trim();
//            const email = row.cells[3].textContent.trim();
//            const ban = row.cells[4].textContent.trim();
//            const role = row.cells[5].textContent.trim();  // Lấy giá trị Role
//            const points = row.cells[6].textContent.trim();  // Lấy giá trị Points

//            // Điền dữ liệu vào form
//            document.getElementById("userId").value = userId;
//            document.getElementById("userFullName").value = fullName;
//            document.getElementById("phone").value = phone;
//            document.getElementById("userEmail").value = email;
//            document.getElementById("userBan").value = ban;
//            document.getElementById("userRole").value = role;  // Điền Role vào form
//            document.getElementById("userPoints").value = points;  // Điền Points vào form

//            // Hiển thị form chỉnh sửa
//            userForm.classList.remove("d-none");
//        });
//    });
//});

//document.addEventListener("DOMContentLoaded", function () {
//    const deleteButtons = document.querySelectorAll(".delete-btn");

//    deleteButtons.forEach((btn) => {
//        btn.addEventListener("click", function () {
//            const userId = this.getAttribute("data-id");

//            // Xác nhận trước khi xóa
//            if (confirm("Are you sure you want to delete this user?")) {
//                // Gửi yêu cầu POST để xóa người dùng
//                fetch(`/Admin/Delete/${userId}`, {
//                    method: "POST",
//                    headers: {
//                        "Content-Type": "application/json"
//                    },
//                })
//                    .then(response => {
//                        if (response.ok) {
//                            // Sau khi xóa thành công, xóa dòng trong bảng (DOM)
//                            const row = this.closest("tr");
//                            row.remove();
//                        } else {
//                            alert("Error deleting user: " + response.statusText);
//                        }
//                    })
//                    .catch(error => {
//                        console.error("Error:", error);
//                        alert("Error deleting user");
//                    });
//            }
//        });
//    });
//});
