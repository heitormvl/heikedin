function formatarCPF(input) {
  let cpf = input.value.replace(/\D/g, "");
  if (cpf.length > 3 && cpf.length <= 6) {
    cpf = cpf.replace(/(\d{3})(\d+)/, "$1.$2");
  } else if (cpf.length > 6 && cpf.length <= 9) {
    cpf = cpf.replace(/(\d{3})(\d{3})(\d+)/, "$1.$2.$3");
  } else if (cpf.length > 9) {
    cpf = cpf.replace(/(\d{3})(\d{3})(\d{3})(\d+)/, "$1.$2.$3-$4");
  }
  input.value = cpf;
}

document.addEventListener("DOMContentLoaded", function () {
  const formGroups = document.querySelectorAll(".form-group");
  const avancarBtn = document.getElementById("avancarBtn");
  const nomeInput = document.querySelector('input[name="Nome"]');

  // Esconde todos os campos inicialmente
  formGroups.forEach((group) => group.classList.remove("visible"));

  avancarBtn.addEventListener("click", function () {
    const nomeTop = nomeInput.offsetTop;
    window.scrollTo({
      top: nomeTop - 100,
      behavior: "smooth",
    });

    setTimeout(() => {
      document.getElementById("jobForm").classList.add("visible");
      formGroups[0].classList.add("visible");
      nomeInput.focus();
    }, 500);

    this.style.display = "none";
  });

  // Animação dos campos
  formGroups.forEach((group, index) => {
    if (index < formGroups.length - 1) {
      const input = group.querySelector("input, textarea");
      input.addEventListener("input", function () {
        if (this.value.trim() !== "") {
          setTimeout(() => {
            formGroups[index + 1].classList.add("visible");
          }, 300);
        } else {
          for (let i = index + 1; i < formGroups.length; i++) {
            formGroups[i].classList.remove("visible");
          }
        }
      });
    }
  });
});
