<template>
    <div :class="['toast-message', type]">
        <!-- <div class="icon icon-x" @click="close"></div> -->
        {{message}}
    </div>
</template>
<script>
export default {
    props: {
        type: String,
        message: String,
    },
    methods: {
        close() {
            this.$emit('close');
        }
    },
    mounted() {
        setTimeout(() => {
            this.close();
        }, 3000);
    }
}
</script>
<style scoped>
.toast-message {
    width: 100%;
    border-radius: 8px;
    padding: 16px 8px 16px 8px;
    margin-bottom: 4px;
    color: #ffffff;
}

.icon {
    position: absolute;
    width: 16px;
    height: 16px;
    top: 4px;
    right: 4px;
}

.ERROR {
    background-color: #c74244;
}

.SUCCESS {
    background-color: #4aa255;
}
</style>