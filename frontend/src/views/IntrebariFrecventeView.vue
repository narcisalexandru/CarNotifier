<template>
    <div class="flex flex-column justify-content-center align-items-center p-8 h-screen gap-5">
        <h1 class="text-3xl text-white"> Întrebări frecvente </h1>
        <CustomPanel class="w-9" header="Ce informații trebuie să introduc pentru a primi notificări?" toggleable collapsed>
            <p class="m-0">
                Va trebui să introduceți numărul de înmatriculare al vehiculului, data de expirare a RCA-ului, a rovinietei și a ITP-ului, și o adresă de email pentru a primi notificările.
            </p>
        </CustomPanel>
        <CustomPanel class="w-9" header="Cât costă să folosesc această platformă?" toggleable collapsed>
            <p class="m-0">
                Platforma noastră este complet gratuită și poate fi utilizată nelimitat fără niciun cost. Toate funcțiile, inclusiv notificările privind expirarea RCA-ului, rovinietei și ITP-ului, sunt disponibile gratuit pentru toți utilizatorii.
            </p>
        </CustomPanel>
        <CustomPanel class="w-9" header="Cum mă înscriu pe platformă?" toggleable collapsed>
            <p class="m-0">
                Pentru a utiliza platforma noastră nu este nevoie să-ți faci un cont. Tot ce trebuie să faci este să introduci adresa ta de email pentru a putea primi notificările. Este simplu și rapid!
            </p>
        </CustomPanel>
        <CustomPanel class="w-9" header="Ce fac dacă am nevoie de ajutor sau am întâmpinat o problemă?" toggleable collapsed>
            <p class="m-0">
                Dacă ai nevoie de ajutor sau ai întâmpinat o problemă, pe platforma noastră există o secțiune dedicată unde poți primi suport. În meniul de sus vei găsi un buton "Contact". Apasă pe acest buton și vei găsi o casuță unde ne poți transmite problema ta. Echipa noastră îți va oferi suport în cel mai scurt timp posibil.
            </p>
        </CustomPanel>
        <CustomPanel class="w-9" header="Cum și când voi primi notificările?" toggleable collapsed>
            <p class="m-0">
                Notificările sunt trimise cu o zi înainte de expirarea serviciului selectat. Vei primi un email în care vom menționa numărul de înmatriculare al vehiculului și tipul de serviciu care urmează să expire. Astfel, vei fi mereu la curent cu datele importante și vei putea lua măsurile necesare la timp.
            </p>
        </CustomPanel>
    </div>
</template>

<script setup lang="ts">

</script>

<style>
.p-panel {
    background-color: rgba(106, 117, 130, 0.2);
    color: white;
}
.p-panel-content {
    color: white;
}
.p-panel-header {
    color: white;
}
</style>
