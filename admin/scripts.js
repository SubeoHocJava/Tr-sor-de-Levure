document.querySelector('.search-btn').addEventListener('click', function () {
	this.parentElement.classList.toggle('open')
	this.previousElementSibling.focus()
})

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


