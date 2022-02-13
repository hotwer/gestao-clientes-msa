<template>
    <b-modal id="confirmation-dialog">
        {{ dialogMessage }}
        <template #modal-footer>
            <div>
                <b-row>
                    <b-col>
                        <b-button v-on:click="closeDialog(true)" variant="primary">Sim</b-button>
                    </b-col>
                    <b-col>
                        <b-button v-on:click="closeDialog(false)" variant="secondary">Cancelar</b-button>
                    </b-col>
                </b-row>
            </div>
        </template>
    </b-modal>
</template>

<script>
const CONFIRMATION_MODAL_ID = 'confirmation-dialog'; 

export default {
    name: "ConfirmationDialog",
    data() {
        return {
            dialogMessage: "",
        }
    },
    methods: {
        closeDialog(confirmation) {
            this._dialogCallback(confirmation);
            this.$bvModal.hide(CONFIRMATION_MODAL_ID);
        },
    },
    mounted() {
        const self = this;
        
        this.$root.$on('dialoger:ask', (options) => {
            const { message, callback } = options;

            self.dialogMessage = message;
            self._dialogCallback = callback;

            this.$bvModal.show(CONFIRMATION_MODAL_ID);
        });
    }
}

</script>

<style scoped>
</style>